using Microsoft.EntityFrameworkCore;
using spayserver.Data.Contexts;
using spayserver.Data.DTOs;
using spayserver.Data.Models;

namespace spayserver.Data.Repositories.GroupRepo
{
    public class GroupRepository : IGroupRepository
    {
        private readonly SpaydbContext _context;
        public GroupRepository(SpaydbContext context)
        {
            _context = context;
        }   

        public async Task<IEnumerable<Group>> GetGroupsAsync()
        {
            return await _context.Groups.ToListAsync();
        }

        public async Task<Group> GetGroupByIdAsync(int id)
        {
            return await _context.Groups.FirstOrDefaultAsync(g => g.GroupId == id);
        }

        public async Task<IEnumerable<Group>> GetGroupByNameAsync(string groupName)
        {
            return await _context.Groups.Where(g => g.GroupName.Contains(groupName)).ToListAsync();
        }

        public async Task<GroupDTO> CreateGroupAsync(AddGroupDTO groupDTO)
        {
       
            var user = _context.Users.FirstOrDefault(item => groupDTO.UserId == item.UserId);
            if (user == null)
                throw new InvalidOperationException("Invalid User");

            var newGroup = new Group
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName,
                Users = [user]
            };
            _context.Groups.Add(newGroup);
            await _context.SaveChangesAsync();
            return new GroupDTO
            {
                GroupId = groupDTO.GroupId,
                GroupName = groupDTO.GroupName
            };
        }
    }
}
