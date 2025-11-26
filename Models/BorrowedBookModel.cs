

namespace Library_Management_System.Models
{
    public class BorrowedBookModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public DateTime BorrowedAt { get; set; }


        public DateTime? ReturnedAt { get; set; }
    }
}
