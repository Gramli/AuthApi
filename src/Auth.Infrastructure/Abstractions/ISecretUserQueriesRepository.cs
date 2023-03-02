using Auth.Infrastructure.Database.EFContext.Entities;
using FluentResults;

namespace Auth.Infrastructure.Abstractions
{
    internal interface ISecretUserQueriesRepository
    {
        Task<Result<UserEntity>> GetUser(int id, CancellationToken cancellationToken);
        Task<Result<UserEntity>> FindUser(string username, CancellationToken cancellationToken);
    }
}
