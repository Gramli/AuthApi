using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Repositories;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Database.EFContext.Entities;
using Auth.Infrastructure.Resources;
using FluentResults;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database.Repositories
{
    internal class UserQueriesRepository : IUserQueriesRepository, ISecretUserQueriesRepository
    {
        private readonly UserContext _context;
        public UserQueriesRepository(UserContext userContext)
        {
            _context = Guard.Against.Null(userContext);
        }
        public async Task<Result<UserEntity>> FindUser(string username, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Username.Equals(username));
            return GetUserResult(user);
        }

        public async Task<Result<UserEntity>> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id.Equals(id));
            return GetUserResult(user);
        }

        private Result<UserEntity> GetUserResult(UserEntity? user)
        {
            return user is not null ? Result.Ok(user) : Result.Fail<UserEntity>(DatabaseErrorMessages.UserNotExist);
        }
    }
}
