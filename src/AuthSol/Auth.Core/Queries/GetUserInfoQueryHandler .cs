using Auth.Core.Abstractions.Queries;
using Auth.Domain.Dtos;
using Auth.Domain.Http;

namespace Auth.Core.Queries
{
    internal class GetUserInfoQueryHandler : IGetUserInfoQueryHandler
    {
        public Task<HttpDataResponse<IEnumerable<UserDto>>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
