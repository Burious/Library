using BookApi.Db;
using Library.Db;
using Library.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public class UserService : IUserService
    {
        private readonly UsersDBContext _uContext;
        private readonly BookContext _bContext;
        public UserService(UsersDBContext uContext, BookContext bContext)
        {
            _uContext = uContext;
            _bContext = bContext;
        }
        public async Task<IEnumerable<User>> Get()
        {
            return await _uContext.Users.ToListAsync();
        }

        /*public async Task Transmit()
        {
            var users = await _uContext.Users.ToListAsync();
            await _bContext.AddRangeAsync(users);
            await _bContext.SaveChangesAsync();
        }*/

    }
}

