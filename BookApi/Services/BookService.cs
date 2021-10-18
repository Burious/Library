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


        public async Task<RemoteBook> Create(string userName, string title,string author, string description, string publishment, int yearOfPublish)
        {

            var book = new RemoteBook()
            {
                Id = Guid.NewGuid(),
                Title = title,
                Author = author,
                Description = description,
                Publishment = publishment,
                YearOfPublish = new DateTime(yearOfPublish, 1, 1),
                CustomerInfo = _context.Users.Where(u => u.UserName == userName).ToList().First(),
                //CustomerInfoId = Guid.NewGuid()
            };

            _context.RemoteBooks.Add(book);
            await _context.SaveChangesAsync();

            return book;
        }

        /*public async Task Delete(string userName, Guid id)
        {
            var userToUpdate = await _context.Users.FindAsync(userName);
            var bookToDelete = await _context.RemoteBooks.FindAsync(id);
            _context.RemoteBooks.Remove(bookToDelete);
            await _context.SaveChangesAsync();
        }*/
        //done
        public async Task<IEnumerable<RemoteBook>> Get(string userName)
        {
            var books = _context.RemoteBooks.Where(b => b.CustomerInfo.UserName == userName).ToList();
            return books;
        }
        //?
       /* public async Task<RemoteBook> Get(string userName, Guid id)
        {
            return await _context.RemoteBooks.FindAsync(id);
        }*/

        /*public async Task Update(string userName, RemoteBook book)
        {
            _context.Entry(book).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }*/
    }
}
