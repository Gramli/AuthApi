using Auth.Domain.Dtos;

namespace Auth.Core.Abstractions
{
    public interface ITokenService
    {
        public string GenerateToken(UserDto user);
    }
}
