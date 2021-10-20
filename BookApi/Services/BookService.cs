using BookApi.Db;
using BookApi.Models;
using Library.Db;
using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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


        public async Task<RemoteBook> Create(string userName, string title,string author, string description, string publishment, int? yearOfPublish)
        {

            var book = new RemoteBook()
            {
                Id = Guid.NewGuid(),
                Title = title != null ? title: string.Empty,
                Author = author != null ? author : string.Empty,
                Description = description != null ? description : string.Empty,
                Publishment = publishment != null ? publishment : string.Empty,
                YearOfPublish = yearOfPublish != null ? new DateTime(yearOfPublish.Value, 1, 1) : new DateTime(1, 1, 1),
                CustomerInfo = _context.Users.Where(u => u.UserName == userName).ToList().First(),
                //CustomerInfoId = Guid.NewGuid()
            };

            _context.RemoteBooks.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        public async Task Delete(Guid id)
        {
           // var userToUpdate = await _context.Users.FindAsync(userName);
            var bookToDelete = await _context.RemoteBooks.FindAsync(id);
            _context.RemoteBooks.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }
        //done
        public async Task<IEnumerable<RemoteBook>> Get(string userName)
        {
            var books = _context.RemoteBooks.Where(b => b.CustomerInfo.UserName == userName).ToList().OrderBy(b=>b.Title);
            return books;
        }
        //?
        public async Task<RemoteBook> Get(Guid id)
        {
            return await _context.RemoteBooks.FindAsync(id);
        }

        public async Task Update(string userName, RemoteBook book)
        {
            book.CustomerInfo = _context.Users.Where(u => u.UserName == userName).ToList().First();
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
