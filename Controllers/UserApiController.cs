using Library_Management_System.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library_Management_System.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserApiController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserApiController(IUserService userService)
        {
            _userService = userService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("Get-all-users")]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAllUsersAsync();
            return Ok(users);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet("Make-a-user-Admin")]
        public async Task<IActionResult> MakeAdmin(string username)
        {
            var success = await _userService.MakeAdminAsync(username);

            if (!success)
            {
                return BadRequest("User is already an admin or does not exist.");
            }

            return Ok($"{username} is now an Admin.");
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete-a-user")]
        public async Task<IActionResult> DeleteUser(string username)
        {
            var currentUsername = User.Identity?.Name;

            if (string.Equals(currentUsername, username))
            {
                return BadRequest("You cannot delete yourself.");
            }

            var success = await _userService.DeleteUserAsync(username);

            if (!success)
            {
                return BadRequest("User not found.");
            }

            return Ok($"{username} is removed from the system.");
        }
    }
}
