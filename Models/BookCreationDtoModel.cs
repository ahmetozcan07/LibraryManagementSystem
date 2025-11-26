

using System.ComponentModel.DataAnnotations;

namespace Library_Management_System.Models
{
    public class BookCreationDtoModel
    {
        [Required(ErrorMessage = "Book title is needed.")]
        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public int CopiesAvailable { get; set; }

        public int TimesBorrowed { get; set; } = 0;
    }
}
