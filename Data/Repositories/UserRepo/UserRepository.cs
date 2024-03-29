﻿using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using spayserver.Data.Contexts;
using spayserver.Data.DTOs;
using spayserver.Data.Models;

namespace spayserver.Data.Repositories.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly SpaydbContext _context;

        public UserRepository(SpaydbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserId == id);
        }

        public async Task<IEnumerable<User>> GetUserByNameAsync(string searchTerm)
        {
            return await _context.Users.Where(u => 
                                                u.Username.Contains(searchTerm)||
                                                u.FirstName.Contains(searchTerm)||
                                                u.LastName.Contains(searchTerm)).ToListAsync();
        }
<<<<<<< HEAD

||||||| 07773a0
=======

        public async Task<UpdateUserDTO> UpdateUserByIdAsync(int Id, JsonPatchDocument<UserDTO> userDto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(a => a.UserId == Id);
            if (user == null) { return null; }

            var newUserDTO = new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                UserId = user.UserId
            };

            userDto.ApplyTo(newUserDTO);

            user.FirstName = newUserDTO.FirstName;
            user.LastName = newUserDTO.LastName;
            user.Email = newUserDTO.Email;
            user.Username = newUserDTO.Username;

            
            await _context.SaveChangesAsync();
            return new UpdateUserDTO
            { 
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username
            };
        }
>>>>>>> e5dd9980aea34e52aec0ff1f3a89e9e208fbdf04
    }
}
