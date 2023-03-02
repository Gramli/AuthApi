using Auth.Domain.Dtos;
using Auth.Domain.Http;

namespace Auth.Core.Abstractions.Queries
{
    public interface IGetUserInfoQueryHandler : IRequestHandler<IEnumerable<UserDto>,EmptyRequest>
    {
    }
}
