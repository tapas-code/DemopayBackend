namespace spayserver.Data.DTOs
{
    public class UpdateUserDTO
    {
        public string Username { get; set; } = null!;
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public decimal Amount { get; set; } = decimal.Zero;
    }
}
