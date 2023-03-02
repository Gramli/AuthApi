using Auth.Domain.Dtos;

namespace Auth.Core.Abstractions.Services
{
    public interface ITokenService
    {
        public string GenerateToken(UserDto user);
    }
}
