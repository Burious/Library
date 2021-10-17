using BookApi.Db;
using BookApi.Models;
using Library.Db;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookApi.Services
{
    public class BookService : IBookService
    {
        private readonly RemoteBooksDBContext _context;
        public BookService(RemoteBooksDBContext context)
        {
            _context = context;
        }
        public async Task<RemoteBook> Create(RemoteBook book)
        {
            _context.RemoteBooks.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(Guid id)
        {
            var bookToDelete = await _context.RemoteBooks.FindAsync(id);
            _context.RemoteBooks.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<RemoteBook>> Get()
        {
            return await _context.RemoteBooks.ToListAsync();
        }

        public async Task<RemoteBook> Get(Guid id)
        {
            return await _context.RemoteBooks.FindAsync(id);
        }

        public async Task Update(RemoteBook book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
