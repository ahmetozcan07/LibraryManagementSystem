using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Library_Management_System.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookApiController : ControllerBase
    {
        private readonly IReadableBookService _readService;
        private readonly IWritableBookService _writeService;
        private const string admin = "Admin";

        public BookApiController(IReadableBookService readService, IWritableBookService writeService)
        {
            _readService = readService;
            _writeService = writeService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetBooksAsync()
        {
            var books = await _readService.GetBooksAsync();
            return Ok(books);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<IActionResult> GetBookByIdAsync(int id)
        {
            var book = await _readService.GetBookByIdAsync(id);
            if(book == null) return NotFound();
            return Ok(book);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns all books grouped by authors.</returns>
        [HttpGet("Group-by-author")]
        [Authorize]
        public async Task<IActionResult> GetBooksGroupedByAuthor()
        {
            var result = await _readService.GetBooksGroupedByAuthorAsync();
            return Ok(result);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns>Returns top 3 most borrowed books.</returns>
        [HttpGet("top-borrowed")]
        [Authorize]
        public async Task<IActionResult> GetTopBorrowedBooks()
        {
            var result = await _readService.GetTopBorrowedBooksAsync();
            return Ok(result);
        }

        [HttpGet("Fetch-book-external/{id}")]
        [Authorize]
        public async Task<IActionResult> FetchBookFromExternalApi(int id)
        {
            var book = await _readService.FetchBookDetailsFromExternalApiAsync(id);
            if( book == null ) return NotFound();
            return Ok(book);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Adds a new book.</returns>
        [HttpPost]
        [Authorize(Roles = admin)]
        public async Task<IActionResult> AddAsync(BookModel book)
        {
            var created = await _writeService.AddBookAsync(book);
            return CreatedAtAction(nameof(GetBookByIdAsync), new { id = created.Id }, created);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="book"></param>
        /// <returns>Update an existing book.</returns>
        [HttpPut("{id}")]
        [Authorize(Roles = admin)]
        public async Task<IActionResult> UpdateBookAsync(BookModel book)
        {
            var updated = await _writeService.UpdateBookAsync(book);
            if (updated == null) return NotFound();
            return Ok(updated);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Delete a book.</returns>
        [HttpDelete("{id}")]
        [Authorize(Roles = admin)]
        public async Task<IActionResult> DeleteBookAsync(int id)
        {
            var deleted = await _writeService.DeleteBookAsync(id);
            if (!deleted) return NotFound();
            return Ok("Book deleted successfully.");
        }
    }
} 