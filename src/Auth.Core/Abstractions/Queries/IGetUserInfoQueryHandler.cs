using Auth.Domain.Dtos;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;

namespace Auth.Core.Abstractions.Queries
{
    public interface IGetUserInfoQueryHandler : IHttpRequestHandler<IEnumerable<UserDto>,EmptyRequest>
    {
    }
}
