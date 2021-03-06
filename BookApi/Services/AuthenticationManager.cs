using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using BookApi.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BookApi.Db;
using Library.Db;
using Library.Models;

namespace BookApi.Services
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _configuration;
        private IdentityUser _user;
       // private static int id = 10;
        private readonly AuthContext _context;
        private readonly RemoteBooksDBContext _remContext;

        public AuthenticationManager(UserManager<IdentityUser> userManager, IConfiguration configuration, AuthContext context,RemoteBooksDBContext remContext)
        {
            _userManager = userManager;
            _configuration = configuration;
            _context = context;
            _remContext = remContext;
        }

        public async Task<bool> ValidateCredentials(AuthCredentials credentials)
        {
            _user = await _userManager.FindByNameAsync(credentials.Username);
            return _user != null && await _userManager.CheckPasswordAsync(_user, credentials.Password);
        }

        public async Task<string> CreateToken()
        {
            var jwtsettings = _configuration.GetSection("JwtSettings");

            var claims = await GetClaims();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtsettings.GetSection("secret").Value));
            var signingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtsettings.GetSection("validIssuer").Value,
                audience: jwtsettings.GetSection("validAudience").Value,
                claims: claims,
                expires: DateTime.Now.AddMinutes(60),
                signingCredentials: signingCredentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        private async Task<List<Claim>> GetClaims()
        {
            var claims = new List<Claim>
            { new Claim(ClaimTypes.Name, _user.UserName) };

            var roles = await _userManager.GetRolesAsync(_user);
            foreach (var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }
            return claims;
        }
        public async Task<IEnumerable<IdentityUser>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<IdentityUser> CreateUser( string username, string email, string password)
        {
            var modelBuilder = new ModelBuilder();
            var ph = new PasswordHasher<IdentityUser>();
            var user = new IdentityUser
            {
                Id = Guid.NewGuid().ToString(),//(++id).ToString(),
                UserName = username,
                NormalizedUserName = username.ToUpper(),
                Email = email,
                EmailConfirmed = true
            };
            user.PasswordHash = ph.HashPassword(user, password);
            UsersDatabaseSeeder.SeedUserRoles(modelBuilder, user.Id);
            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            _remContext.Users.Add(new User() {Id = Guid.NewGuid(), UserName = username, RemoteBooks = new HashSet<RemoteBook>() });
            await _remContext.SaveChangesAsync();
            modelBuilder.Entity<IdentityUser>().HasData(user);
            return user;
        }
    }
}
