using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface IRoleQueriesRepository
    {
        Task<IEnumerable<RoleEntity>> GetRoleEntities(CancellationToken cancellationToken);
        Task<Result<RoleEntity>> GetRoleEntity(string roleName, CancellationToken cancellationToken);
    }
}
