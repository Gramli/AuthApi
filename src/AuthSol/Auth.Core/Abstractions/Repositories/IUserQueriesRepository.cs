using Auth.Domain.Dtos;

namespace Auth.Core.Abstractions.Repositories
{
    public interface IUserQueriesRepository
    {
        Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken);
    }
}
