using Microsoft.EntityFrameworkCore;
using spayserver.Data.Contexts;
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

    }
}
