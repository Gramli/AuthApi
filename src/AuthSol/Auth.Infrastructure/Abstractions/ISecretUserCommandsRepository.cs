using Auth.Infrastructure.Database.EFContext.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface ISecretUserCommandsRepository
    {
        Task<int> AddUser(UserEntity userEntity, CancellationToken cancellationToken);
        Task<Result<bool>> ChangeUserRole(UserEntity user, string role, CancellationToken cancellationToken);
    }
}
