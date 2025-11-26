using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Interfaces
{
    public interface IAuthService
    {
        Task<bool> RegisterAsync(LoginRequestModel request);

        Task<AuthResponseModel?> LoginAsync(LoginRequestModel request);
    }
}
