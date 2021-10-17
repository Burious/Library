using BookApi.Models;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<RemoteBook>> Get();
        Task<RemoteBook> Get(Guid id);
        Task<RemoteBook> Create(RemoteBook book);
        Task Update(RemoteBook book);
        Task Delete(Guid id);
    }
}
