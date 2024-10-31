using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using FluentResults;

namespace Auth.Core.Abstractions.Services
{
    public interface IAccountService
    {
        Task<Result<UserDto>> FindUser(LoginCommand loginCommand, CancellationToken cancellationToken);
        Task<Result<int>> CreateNewUser(RegisterCommand registerCommand, CancellationToken cancellationToken);
    }
}
