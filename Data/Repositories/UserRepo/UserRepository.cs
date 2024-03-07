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

        //public async Task<User> GetUserByIdAsync(int id)
        //{
        //    var user = await _context.Users.FirstOrDefaultAsync(u => u.userId == id);
        //}
    }
}
