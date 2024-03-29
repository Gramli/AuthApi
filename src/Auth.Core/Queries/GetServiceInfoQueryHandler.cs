﻿using Auth.Core.Abstractions.Queries;
using Auth.Domain.Dtos;
using Auth.Domain.Extensions;
using Auth.Domain.Http;

namespace Auth.Core.Queries
{
    internal class GetServiceInfoQueryHandler : IGetServiceInfoQueryHandler
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
