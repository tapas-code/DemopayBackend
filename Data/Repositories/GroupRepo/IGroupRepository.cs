using spayserver.Data.DTOs;
using spayserver.Data.Models;

namespace spayserver.Data.Repositories.GroupRepo
{
    public interface IGroupRepository
    {
        Task<IEnumerable<Group>> GetGroupsAsync();
        Task<Group> GetGroupByIdAsync(int id);
        Task<IEnumerable<Group>> GetGroupByNameAsync(string groupName);

        Task<GroupDTO> CreateGroupAsync(AddGroupDTO groupDTO);
    }
}
