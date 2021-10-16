using Library.Models;
using Library.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("api/users")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        // private readonly ILogger<BooksController> _logger;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// users
        /// </summary>
        /// <returns>Collection of books</returns>
        [HttpGet, Authorize(Roles = "admin")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userService.Get();
        }

       /* [HttpPut, Authorize(Roles = "admin")]
        public async Task Transmit()
        {
          await _userService.Transmit();

        }*/


    }
}
