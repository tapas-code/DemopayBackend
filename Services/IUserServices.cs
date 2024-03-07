using spayserver.Data.DTOs;

namespace spayserver.Services
{
    public interface IUserServices
    {
        Task<IEnumerable<UserDTO>> GetUsersAsync();
    }
}
