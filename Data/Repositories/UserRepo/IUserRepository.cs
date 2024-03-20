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
<<<<<<< HEAD
 
||||||| 07773a0
=======
        Task<UpdateUserDTO> UpdateUserByIdAsync(int Id, JsonPatchDocument<UserDTO> userDto);
>>>>>>> e5dd9980aea34e52aec0ff1f3a89e9e208fbdf04
    }
}
