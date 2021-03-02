using Core.Models;

namespace Core
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}