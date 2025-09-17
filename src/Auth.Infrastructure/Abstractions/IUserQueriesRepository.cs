using Auth.Infrastructure.UseCases.User.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface IUserQueriesRepository
    {
        Task<Result<UserEntity>> GetUser(int id, CancellationToken cancellationToken);
        Task<Result<UserEntity>> FindUser(string username, CancellationToken cancellationToken);
    }
}
