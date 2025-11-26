using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IReadableBookService
    {
        Task<IEnumerable<BookModel>> GetBooksAsync();

        Task<BookModel?> GetBookByIdAsync(int id);

        Task<IEnumerable<BookModel>> GetBooksGroupedByAuthorAsync();
        Task<IEnumerable<BookModel>> GetTopBorrowedBooksAsync(int top = 3);

        Task<BookModel?> FetchBookDetailsFromExternalApiAsync(int id);

    }
}
