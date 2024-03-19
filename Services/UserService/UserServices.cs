using spayserver.Data.DTOs;
using spayserver.Data.Models;
using spayserver.Data.Repositories.UserRepo;

namespace spayserver.Services.UserService
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

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _userRepository.GetUserByIdAsync(id);
            if (user == null) return null;
            return MapToDTO(user);
        }

        public async Task<IEnumerable<UserDTO>> GetUserByNameAsync(string searchTerm)
        {
            var users = await _userRepository.GetUserByNameAsync(searchTerm);
            if (users == null) return null;
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
                Amount = (decimal)user.Amount,
                Phone = user.Phone,
                imgUrl = user.imgUrl
            };
        }
    }
}
