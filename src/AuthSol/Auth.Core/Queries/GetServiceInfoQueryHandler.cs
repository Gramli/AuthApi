using Auth.Core.Abstractions.Queries;
using Auth.Domain.Dtos;
using Auth.Domain.Http;

namespace Auth.Core.Queries
{
    internal class GetServiceInfoQueryHandler : IGetServiceInfoQueryHandler
    {
        public Task<HttpDataResponse<ServiceInfoDto>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
