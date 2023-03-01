using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Database.EFContext.Entities;
using File.Domain.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database.Repositories
{
    internal class RoleCommandRepository : ISecretRoleCommandRepository
    {
        private readonly UserContext _context;
        public RoleCommandRepository(UserContext userContext)
        {
            _context = Guard.Against.Null(userContext);
        }

        public async Task AddRoles(IEnumerable<string> roles, CancellationToken cancellationToken)
        {
            await roles.ForEachAsync(async (role) => await _context.Roles.AddAsync(new RoleEntity { Role = role }, cancellationToken));
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}
