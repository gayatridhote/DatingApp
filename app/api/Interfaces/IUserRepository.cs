using api.DTOs;
using api.entities;
using api.Helpers;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id );
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<PageList<MembersDto>>GetMembersAsync(UserParams userParams);
        Task<MembersDto>GetMemberAsync(string username);
        
        
        
    }
}