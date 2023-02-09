using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Database.EFContext.Entities;

namespace Auth.Infrastructure.Database.Repositories
{
    internal class UserCommandsRepository : IUserCommandsRepository, ISecretUserCommandsRepository
    {
        private readonly UserContext _context;
        public UserCommandsRepository(UserContext userContext)
        {
            _context = Guard.Against.Null(userContext);
        }
        public async Task<int> AddUser(UserEntity userEntity, CancellationToken cancellationToken)
        {
            await _context.Users.AddAsync(userEntity);
            await _context.SaveChangesAsync(cancellationToken);
            return userEntity.Id;
        }
    }
}
