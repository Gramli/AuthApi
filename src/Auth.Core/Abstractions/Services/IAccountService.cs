using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using FluentResults;

namespace Auth.Core.Abstractions.Services
{
    public interface IAccountService
    {
        Task<Result<UserDto>> FindUser(LoginCommand loginCommand, CancellationToken cancellationToken);
        Task<Result<int>> CreateNewUser(RegisterCommand registerCommand, CancellationToken cancellationToken);
    }
}
