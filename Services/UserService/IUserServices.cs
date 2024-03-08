using spayserver.Data.DTOs;

namespace spayserver.Services.UserService
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
        Task<UserDTO> GetUserByIdAsync(int id);
        Task<IEnumerable<UserDTO>> GetUserByNameAsync(string searchTerm);
    }
}
