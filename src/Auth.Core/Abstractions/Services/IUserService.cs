using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using FluentResults;

namespace Auth.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken);
        Task<Result<UserInfoDto>> GetAuthorizedUser(CancellationToken cancellationToken);
        Task<Result<UserInfoDto>> GetUser(string name, CancellationToken cancellationToken);
    }
}
