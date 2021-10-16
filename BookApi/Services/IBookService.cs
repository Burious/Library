﻿using BookApi.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> Get();
        Task<Book> Get(Guid id);
        Task<Book> Create(Book book);
        Task Update(Book book);
        Task Delete(Guid id);
    }
}
