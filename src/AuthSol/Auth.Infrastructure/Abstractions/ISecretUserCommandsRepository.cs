using Auth.Infrastructure.Database.EFContext.Entities;

namespace Auth.Infrastructure.Abstractions
{
    internal interface ISecretUserCommandsRepository
    {
        Task<int> AddUser(UserEntity userEntity, CancellationToken cancellationToken);
    }
}
