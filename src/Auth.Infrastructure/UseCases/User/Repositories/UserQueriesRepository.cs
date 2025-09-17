using Ardalis.GuardClauses;
using Auth.Domain.UseCases.User.Dto;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Resources;
using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.UseCases.User.Repositories
{
    internal sealed class UserQueriesRepository : Core.Abstractions.Repositories.IUserQueriesRepository, Abstractions.IUserQueriesRepository
    {
        private readonly UserContext _context;
        public UserQueriesRepository(UserContext userContext)
        {
            _context = Guard.Against.Null(userContext);
        }
        public async Task<Result<UserEntity>> FindUser(string username, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Username.Equals(username));
            return GetUserResult(user);
        }

        public async Task<Result<UserEntity>> GetUser(int id, CancellationToken cancellationToken)
        {
            var user = await _context.Users
                .Include(x => x.Role)
                .SingleOrDefaultAsync(x => x.Id.Equals(id));
            return GetUserResult(user);
        }

        public async Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken)
        {
            return await _context.Users
                .Include(x => x.Role)
                .Select(x => x.Adapt<UserDto>()).ToListAsync();
        }

        private Result<UserEntity> GetUserResult(UserEntity? user)
        {
            return user is not null ? Result.Ok(user) : Result.Fail<UserEntity>(DatabaseErrorMessages.UserNotExist);
        }
    }
}
