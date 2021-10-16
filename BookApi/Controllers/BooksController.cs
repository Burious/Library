using BookApi.Models;
using BookApi.Repositories;
using BookApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// This method shows entire collection of books
        /// </summary>
        /// <returns>Collection of books</returns>
        [HttpGet, Authorize]
        public async Task<IEnumerable<Book>> GetBooks()
        {
            return await _bookService.Get();
        }

        /// <summary>
        /// This method finds a book for suggested Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}"), Authorize]
        public async Task<ActionResult<Book>> GetBook(Guid id)
        {
            return await _bookService.Get(id);
        }

        /// <summary>
        /// This method helps to add a new book to the library
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPost, Authorize(Roles = "admin")]
        public async Task<ActionResult<Book>> PostBooks([FromBody] Book book)
        {
            var newBook = await _bookService.Create(book);
            return CreatedAtAction(nameof(GetBooks), new { id = newBook.Id }, newBook);
        }

        /// <summary>
        /// This method helps to change info about a book with suggested id
        /// </summary>
        /// <param name="id"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut, Authorize(Roles = "admin")]
        public async Task<ActionResult> PutBooks(Guid id, [FromBody] Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            await _bookService.Update(book);

            return NoContent();
        }
        /// <summary>
        /// This method deletes a book with suggested id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}"), Authorize(Roles = "admin")]
        public async Task<ActionResult> Delete(Guid id)
        {
            var bookToDelete = await _bookService.Get(id);
            if (bookToDelete == null) return NotFound();

            await _bookService.Delete(bookToDelete.Id);
            return NoContent();
        }
    }
}
