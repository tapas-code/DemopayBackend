using spayserver.Data.DTOs;
using spayserver.Data.Models;
using spayserver.Data.Repositories.GroupRepo;

namespace spayserver.Services.GroupService
{
    public class GroupServices : IGroupServices
    {
        private readonly IGroupRepository _groupRepository;
        public GroupServices(IGroupRepository groupRepository)
        {
            _groupRepository = groupRepository;
        }

        public async Task<IEnumerable<GroupDTO>> GetGroupsAsync()
        {
            var groups = await _groupRepository.GetGroupsAsync();
            if (groups == null) return null;
            return groups.Select(MapToDTO);
        }

        public async Task<GroupDTO> GetGroupByIdAsync(int id)
        {
            var group = await _groupRepository.GetGroupByIdAsync(id);
            if (group == null) return null;
            return MapToDTO(group);
        }

        public async Task<IEnumerable<GroupDTO>> GetGroupByNameAsync(string groupName)
        {
            var groups = await _groupRepository.GetGroupByNameAsync(groupName);
            if (groups == null) return null;
            return groups.Select(MapToDTO);
        }


        public GroupDTO MapToDTO(Group group)
        {
            return new GroupDTO
            {
                GroupId = group.GroupId,
                GroupName = group.GroupName
            };
        }
    }
}
