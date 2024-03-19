namespace spayserver.Data.DTOs
{
    public class UserDTO
    {
        public int UserId { get; set; }
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Amount { get; set; } = decimal.Zero;
        public string Phone { get; set; } = null!;
        public string imgUrl { get; set; } = null!;
    }
}
