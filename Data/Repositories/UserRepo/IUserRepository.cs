using spayserver.Data.Models;

namespace spayserver.Data.Repositories.UserRepo
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<IEnumerable<User>> GetUserByNameAsync(string searchTerm);
    }
}
