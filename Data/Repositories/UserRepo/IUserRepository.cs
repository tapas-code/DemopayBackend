using Microsoft.AspNetCore.JsonPatch;
using spayserver.Data.DTOs;
using spayserver.Data.Models;

namespace spayserver.Data.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUserByNameAsync(string searchTerm);
        Task<UpdateUserDTO> UpdateUserByIdAsync(int Id, JsonPatchDocument<UserDTO> userDto);
    }
}
