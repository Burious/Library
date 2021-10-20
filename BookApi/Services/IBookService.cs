using BookApi.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<RemoteBook>> Get(string userName);
        Task<RemoteBook> Get(Guid id);
        Task<RemoteBook> Create(string userName, string title, string aithor, string description, string publishment, int? yearOfPublish);
        Task Update(string userName, RemoteBook book);
        Task Delete(Guid id);
    }
}
