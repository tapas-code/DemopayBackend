using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spayserver.Data.DTOs;
using spayserver.Services;

namespace spayserver.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUsersAsync()
        {
            var users = await _userServices.GetUsersAsync();
            if (users == null)
                return NotFound();
            return Ok(users);
        }

        // Get user by id 

        //Get user by username

        // Update user by id 

        // Delete user
    }
}
