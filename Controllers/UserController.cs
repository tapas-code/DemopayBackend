using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using spayserver.Data.DTOs;
using spayserver.Services.UserService;

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
            if (users == null) return NotFound();
            return Ok(users);
        }

        // Get user by id 
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserByIdAsync(int id)
        {
            var user = await _userServices.GetUserByIdAsync(id);
            if(user == null) return NotFound();
            return Ok(user);
        }

        //Get user by username
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<UserDTO>>> GetUserByNameAsync(string searchTerm)
        {
            var users = await _userServices.GetUserByNameAsync(searchTerm);
            if (users == null) return NotFound();
            return Ok(users);
        }

        

        // Update user by id 


        // Delete user
    }
}
