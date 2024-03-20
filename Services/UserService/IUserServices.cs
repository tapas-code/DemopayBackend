using Microsoft.AspNetCore.JsonPatch;
using spayserver.Data.DTOs;

namespace spayserver.Services.UserService
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetUserByNameAsync(string searchTerm);
        Task<UpdateUserDTO> UpdateUserByIdAsync(int Id, JsonPatchDocument<UserDTO> userDto);
    }
}
