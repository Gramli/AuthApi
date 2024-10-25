using Auth.Domain.UseCases.User.Dto;

namespace Auth.Core.Abstractions.Repositories
{
    public interface IUserQueriesRepository
    {
        Task<IEnumerable<UserDto>> GetUsers(CancellationToken cancellationToken);
    }
}
