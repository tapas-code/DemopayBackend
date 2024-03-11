using spayserver.Data.DTOs;
using spayserver.Data.Models;

namespace spayserver.Services.GroupService
{
    public interface IGroupServices
    {
        Task<IEnumerable<GroupDTO>> GetGroupsAsync();
        Task<GroupDTO> GetGroupByIdAsync(int id);
        Task<IEnumerable<GroupDTO>> GetGroupByNameAsync(string groupName);
        Task<GroupDTO> CreateGroupAsync (AddGroupDTO groupDTO);
        Task<GroupDTO> DeleteGroupAsync(int id);


    }
}
