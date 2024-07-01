using api.DTOs;
using api.entities;
using api.Helpers;

namespace api.Interfaces
{
    public interface ILikesRepository
    {
        Task<UserLike> GetUserLike(int sourceUserId, int targetUserId) ;
        Task<AppUser> GetUserWithLikes(int userId);
        Task<PageList<LikeDTO>> GetUserLikes(LikesParams likesParams);
    }
}