

using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Services
{
    public class BookService : IWritableBookService, IReadableBookService
    {
        private readonly AppDbContext _context;

        public BookService(AppDbContext context)
        {
            _context = context;
        }




        // Write Operations
        public async Task<BookModel> AddBookAsync(BookCreationDtoModel bookDto)
        {
            var book = new BookModel
            {
                Title = bookDto.Title,
                Author = bookDto.Author,
                ISBN = bookDto.ISBN,
                CopiesAvailable = bookDto.CopiesAvailable,
                TimesBorrowed = 0
            };

            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<BookModel?> UpdateBookAsync(BookModel book)
        {
            var existingBook = await _context.Books.FindAsync(book.Id);
            if(existingBook != null)
            {
                existingBook.Title = book.Title;
                existingBook.Author = book.Author;
                existingBook.ISBN = book.ISBN;
                existingBook.CopiesAvailable = book.CopiesAvailable;

                await _context.SaveChangesAsync();
                return existingBook;
            }
            return null;
        }


        // Read Operations
        public async Task<BookModel?> GetBookByIdAsync(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return await Task.FromResult(book);
        }

        public async Task<IEnumerable<BookModel>> GetBooksAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<object> GetBooksGroupedByAuthorAsync()
        {
            return await _context.Books
            .GroupBy(b => b.Author)
            .Select(g => new
            {
                Author = g.Key,
                Books = g.ToList()
            })
            .ToListAsync();
        }

        public async Task<IEnumerable<BookModel>> GetTopBorrowedBooksAsync(int top = 3)
        {
            return await _context.Books
                .AsNoTracking()
                .OrderByDescending(b => b.TimesBorrowed)
                .Take(top)
                .ToListAsync();
        }

        public async Task<BookModel?> FetchBookDetailsFromExternalApiAsync(int id)
        {
            await Task.Delay(1000);

            var book = await _context.Books.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);

            if (book != null)
            {
                book.Title += " (Fetched from external API)";
            }

            return book;
        }
    }
}
