using Library_Management_System.Data;
using Library_Management_System.Interfaces;
using Library_Management_System.Models;
using Library_Management_System.Helpers;
using Microsoft.EntityFrameworkCore;

namespace Library_Management_System.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly JwtService _jwtService;

        public AuthService(AppDbContext context, JwtService jwtService)
        {
            _context = context;
            _jwtService = jwtService;
        }

        public async Task<AuthResponseModel?> LoginAsync(LoginRequestModel request)
        {
            var user = await _context.Users.SingleOrDefaultAsync(x => x.Username == request.Username);
            if (user == null)
                return null;

            if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
                return null;

            return _jwtService.GenerateToken(user);
        }

        public async Task<bool> RegisterAsync(LoginRequestModel request)
        {
            if (string.IsNullOrWhiteSpace(request.Username) || string.IsNullOrWhiteSpace(request.Password))
                return false;

            bool exists = await _context.Users.AnyAsync(x => x.Username == request.Username);
            if (exists)
                return false;

            var user = new UserModel
            {
                Username = request.Username,
                PasswordHash = PasswordHasher.Hash(request.Password),
                Role = "User"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}
