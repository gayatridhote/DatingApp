using api.DTOs;
using api.entities;

namespace api.Interfaces
{
    public interface IUserRepository
    {
        void Update(AppUser user);
        Task<bool> SaveAllAsync();
        Task<IEnumerable<AppUser>> GetUsersAsync();
        Task<AppUser> GetUserByIdAsync(int id );
        Task<AppUser> GetUserByUserNameAsync(string username);
        Task<IEnumerable<MembersDto>>GetMembersAsync();
        Task<MembersDto>GetMemberAsync(string username);
        
        
        
    }
}