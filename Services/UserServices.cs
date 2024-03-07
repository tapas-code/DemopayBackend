using spayserver.Data.DTOs;
using spayserver.Data.Models;
using spayserver.Data.Repositories.UserRepo;

namespace spayserver.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _userRepository;
        public UserServices(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<UserDTO>> GetUsersAsync()
        {
            var users = await _userRepository.GetUsersAsync();
            return users.Select(MapToDTO);
        }

        public UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                Username = user.Username,
                Amount = (decimal)user.Amount
            };
        }
    }
}
