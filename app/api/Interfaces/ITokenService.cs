using api.entities;

namespace api.Interfaces
{
    public interface ITokenService
    {
        string CreatToken (AppUser user);
    }
}