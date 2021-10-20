using Microsoft.AspNetCore.Mvc;
using BookApi.Models;
using BookApi.Services;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BookApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IAuthenticationManager _authenticationManager;
        private readonly IAuthenticationManager _authManager;

        public AuthenticationController(IAuthenticationManager authenticationService, IAuthenticationManager manager)
        {
            _authenticationManager = authenticationService;
            _authManager = manager;
        }

        /// <summary>
        /// Get a token for authorization
        /// </summary>
        /// <param name="credentials"></param>
        /// <returns></returns>
        [HttpPost("login")]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Post))]
        public async Task<IActionResult> Login( AuthCredentials credentials)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            if (!await _authenticationManager.ValidateCredentials(credentials))
                return Unauthorized();

            return Ok(new { Token = _authenticationManager.CreateToken() });
        }

        /// <summary>
        /// This method shows entire collection of users
        /// </summary>
        /// <returns></returns>
        [HttpGet("getUsers"), Authorize(Roles = "admin")]
        public async Task<IEnumerable<IdentityUser>> GetUsers()
        {
            return await _authManager.Get();
        }

        /// <summary>
        /// This method helps to create a new user
        /// </summary>
        /// <param name="login"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("createNewUser"), AllowAnonymous]
        [ApiConventionMethod(typeof(DefaultApiConventions),
            nameof(DefaultApiConventions.Post))]
        public async Task<ActionResult<IdentityUser>> CreateUser(string login, string email,string password)
        {
            var newUser = await _authManager.CreateUser(login, email, password);
            return CreatedAtAction(nameof(GetUsers), new { id = newUser.Id }, newUser);
        }
    }
}
