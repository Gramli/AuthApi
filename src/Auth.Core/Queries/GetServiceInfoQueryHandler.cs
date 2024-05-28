using Auth.Core.Abstractions.Queries;
using Auth.Domain.Dtos;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.Response;

namespace Auth.Core.Queries
{
    internal sealed class GetServiceInfoQueryHandler : IGetServiceInfoQueryHandler
    {
        public Task<HttpDataResponse<ServiceInfoDto>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(HttpDataResponses.AsOK(new ServiceInfoDto
            {
                Name = "Auth Service",
                Description = "Successfully get information about service as User"
            }));
        }
    }
}
