using Library.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> Get();
       // Task Transmit();
    }
}
