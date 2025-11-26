using Library_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Library_Management_System.Interfaces;


namespace Library_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthApiController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthApiController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(LoginRequestModel request)
        {
            var success = await _authService.RegisterAsync(request);
            if (!success)
            {
                return BadRequest("Data invalid or username already exists.");
            }
            return Ok("User registered successfully.");
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestModel request)
        {
            var token = await _authService.LoginAsync(request);

            if (token == null)
            {
                return BadRequest("Invalid username or password");
            }
            return Ok(token);
        }
    }
}
