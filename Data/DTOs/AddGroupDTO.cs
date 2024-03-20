using spayserver.Data.Models;

namespace spayserver.Data.DTOs
{
    public class AddGroupDTO
    {
        public int GroupId { get; set; }

        public string GroupName { get; set; } = null!;

        public int UserId { get; set; }
    }
}
