using Bills.Domain.Entities;

namespace Bills.Domain.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
