using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using BookStoreApi.Models;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private static List<Book> books = new List<Book>
        {
            new Book { Id = 1, Title = "Book Title 1", Author = "Author 1", Description = "Description 1", ImageUrl = "image1.jpg" },
            new Book { Id = 2, Title = "Book Title 2", Author = "Author 2", Description = "Description 2", ImageUrl = "image2.jpg" },
            new Book { Id = 3, Title = "Book Title 3", Author = "Author 3", Description = "Description 3", ImageUrl = "image3.jpg" },
        };

        // GET /api/books
        [HttpGet]
        public ActionResult<IEnumerable<Book>> GetBooks()
        {
            return Ok(books);
        }

        // GET /api/books/{id}
        [HttpGet("{id}")]
        public ActionResult<Book> GetBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST /api/books
        [HttpPost]
        public ActionResult<Book> AddBook(Book book)
        {
            book.Id = books.Max(b => b.Id) + 1;
            books.Add(book);
            return CreatedAtAction(nameof(GetBook), new { id = book.Id }, book);
        }

        // PUT /api/books/{id}
        [HttpPut("{id}")]
        public ActionResult UpdateBook(int id, Book updatedBook)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            book.Title = updatedBook.Title;
            book.Author = updatedBook.Author;
            book.Description = updatedBook.Description;
            book.ImageUrl = updatedBook.ImageUrl;

            return NoContent();
        }

        // DELETE /api/books/{id}
        [HttpDelete("{id}")]
        public ActionResult DeleteBook(int id)
        {
            var book = books.FirstOrDefault(b => b.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            books.Remove(book);
            return NoContent();
        }

        // GET /api/books/author/{author}
        [HttpGet("author/{author}")]
        public ActionResult<IEnumerable<Book>> GetBooksByAuthor(string author)
        {
            var booksByAuthor = books.Where(b => b.Author.Equals(author, System.StringComparison.OrdinalIgnoreCase)).ToList();
            return Ok(booksByAuthor);
        }
    }
}
