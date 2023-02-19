using Auth.Domain.Commands;
using FluentResults;

namespace Auth.Core.Abstractions.Services
{
    public interface IUserService
    {
        Task<Result<bool>> ChangeUserRole(ChangeRoleCommand changeRoleCommand, CancellationToken cancellationToken);
    }
}
