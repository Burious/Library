using BookApi.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IAuthenticationManager
    {
        Task<IEnumerable<IdentityUser>> Get();
        Task<bool> ValidateCredentials(AuthCredentials credentials);
        Task<string> CreateToken();
        Task<IdentityUser> CreateUser( string username, string email, string password);
    }
}
