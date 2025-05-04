using Domain;

namespace Application.Interfaces.TokenInterface
{
    public interface ITokenRepository
    {
        public string GenerateToken(User user);
    }
}
