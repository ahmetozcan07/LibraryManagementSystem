
namespace Library_Management_System.Models

{
    public class AuthResponseModel
    {
        public string? Token { get; set; }
        public DateTime ExpiresAt { get; set; }
    }
}
