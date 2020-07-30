using Bills.Domain.Account.Entities;

namespace Bills.Domain.Account.Services
{
    public interface ITokenService
    {
        string GenerateToken(User user);
    }
}
