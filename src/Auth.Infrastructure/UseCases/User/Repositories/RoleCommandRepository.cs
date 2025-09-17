using Ardalis.GuardClauses;
using Auth.Domain.Extensions;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.UseCases.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.UseCases.User.Repositories
{
    internal sealed class RoleCommandRepository : IRoleCommandRepository
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
