

using Library_Management_System.Models;

namespace Library_Management_System.Interfaces
{
    public interface IUserService
    {
        Task<List<UserModel>> GetAllUsersAsync();
        Task<bool> MakeAdminAsync(string username);
        Task<bool> DeleteUserAsync(string username);
    }
}
