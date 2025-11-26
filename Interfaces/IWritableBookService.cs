using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IWritableBookService
    {
        Task<BookModel> AddBookAsync(BookCreationDtoModel book);
        Task<BookModel?> UpdateBookAsync(BookModel book);
        Task<bool> DeleteBookAsync(int id);

        // Borrowing book simulation
        Task<bool> BorrowBookAsync(int bookId);
        Task<bool> ReturnBookAsync(int bookId);
    }
}
