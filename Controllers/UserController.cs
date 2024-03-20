<<<<<<< HEAD
﻿using Azure;
using Microsoft.AspNetCore.Http;
||||||| 07773a0
﻿using Microsoft.AspNetCore.Http;
=======
﻿using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
>>>>>>> e5dd9980aea34e52aec0ff1f3a89e9e208fbdf04
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
        [HttpPatch]
        [Route("{Id}/Update")]
        public async Task<UpdateUserDTO> UpdateUserByIdAsync([FromRoute] int Id,[FromBody] JsonPatchDocument<UserDTO> userDto)
        {
            var user = await _userServices.UpdateUserByIdAsync(Id, userDto);

            if (user == null)
                return null;

            return new UpdateUserDTO
            {
                Amount = user.Amount,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Username = user.Username
            };

        }


        // Delete user
    }
}
