using Auth.Infrastructure.Database.EFContext.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface ISecretRoleQueriesRepository
    {
        Task<IEnumerable<RoleEntity>> GetRoleEntities(CancellationToken cancellationToken);
        Task<Result<RoleEntity>> GetRoleEntity(string roleName, CancellationToken cancellationToken);
    }
}
