using BookApi.Models;
using BookApi.Services;
using DocumentFormat.OpenXml.Spreadsheet;
using Library.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Net.Http;

namespace BookApi.Controllers
{
    /// <summary>
    /// Book Controller
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("api/books")]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        // private readonly ILogger<BooksController> _logger;
        public BooksController(IBookService bookService) //  AuthenticationManager manager
        {
            _bookService = bookService;
        }

        /// <summary>
        /// This method shows entire collection of books
        /// </summary>
        /// <returns>Collection of books</returns>
        [HttpGet("getAllBooks"), Authorize]
        public async Task<IEnumerable<RemoteBook>> GetBooks()
        {
            var name = HttpContext.User.Identity.Name;
            return await _bookService.Get(name); 
        }

        /// <summary>
        /// This method finds a book for suggested Id (or maybe find by book name?)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("getbook{id}"), Authorize]
        public async Task<ActionResult<RemoteBook>> GetBook(Guid id)
        {
            var name = HttpContext.User.Identity.Name;
            return await _bookService.Get(id);
        }

        /// <summary>
        /// This method helps to add a new book to the library
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost("createNewBook")]
        public async Task<ActionResult<RemoteBook>> PostBooks(string title, string author, string description, string publishment, int yearOfPublish)
        {
            var name = HttpContext.User.Identity.Name;
            var newBook = await _bookService.Create(name,title, author, description,publishment, yearOfPublish);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook.Title);
        }

        /// <summary>
        /// This method helps to change info about a book with suggested id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
       [HttpPut("changeBookInformation{id}")]
        public async Task<ActionResult> PutBooks(Guid id, string title, string author, string description, string publishment, int yearOfPublish)
        {
            var book = new RemoteBook { Id = id, Title = title, Author = author, Description = description, Publishment = publishment, YearOfPublish = new DateTime(yearOfPublish,1,1)};
            if (id != book.Id)
            {
                return BadRequest();
            }
            var name = HttpContext.User.Identity.Name;
            await _bookService.Update(name, book);

            return NoContent();
        }
        /// <summary>
        /// This method deletes a book with suggested id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("deleteBook{id}")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var bookToDelete = await _bookService.Get(id);
            if (bookToDelete == null) return NotFound();

            await _bookService.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}
