using Auth.Domain.UseCases.User.Dto;

namespace Auth.Core.Abstractions.Services
{
    public interface ITokenService
    {
        public string GenerateToken(UserDto user);
    }
}
