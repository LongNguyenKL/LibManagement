using LibManagement.Data;
using LibManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public LibraryController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Endpoint to get book details by BookId
        [HttpGet("books/{bookId}")]
        public async Task<IActionResult> GetBookById(int bookId)
        {
            var book = await _context.Books
                .Where(b => b.BookId == bookId)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author,
                    b.Genre,
                    b.PublishedYear,
                    b.Rating
                })
                .FirstOrDefaultAsync();

            if (book == null)
            {
                return NotFound("Book not found.");
            }

            return Ok(book);
        }

        // Endpoint to get books by Genre
        [HttpGet("books/genre/{genre}")]
        public async Task<IActionResult> GetBooksByGenre(string genre)
        {
            var books = await _context.Books
                .Where(b => b.Genre == genre)
                .Select(b => new
                {
                    b.BookId,
                    b.Title,
                    b.Author,
                    b.PublishedYear,
                    b.Rating
                })
                .ToListAsync();

            if (!books.Any())
            {
                return NotFound("No books found in this genre.");
            }

            return Ok(books);
        }
    }
}
