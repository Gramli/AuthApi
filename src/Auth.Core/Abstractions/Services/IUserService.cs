using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using FluentResults;

namespace Auth.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken);
        Task<Result<UserInfoDto>> GetUser(string name, CancellationToken cancellationToken);
    }
}
