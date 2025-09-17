using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface IUserCommandsRepository
    {
        Task<int> AddUser(UserEntity userEntity, CancellationToken cancellationToken);
        Task<Result<bool>> ChangeUserRole(UserEntity user, RoleEntity role, CancellationToken cancellationToken);
    }
}
