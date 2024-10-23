﻿using Auth.Domain.Dtos;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;

namespace Auth.Core.Queries
{
    internal sealed class GetServiceInfoQueryHandler : IHttpRequestHandler<ServiceInfoDto, EmptyRequest>
    {
        public Task<HttpDataResponse<ServiceInfoDto>> HandleAsync(EmptyRequest request, CancellationToken cancellationToken)
        {
            return Task.FromResult(HttpDataResponses.AsOK(new ServiceInfoDto
            {
                Name = "Auth Service",
                Description = "Successfully get information about Auth Service example. If you like it, star it on github :)"
            }));
        }
    }
}
