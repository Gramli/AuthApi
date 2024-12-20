﻿using Auth.Api.Configuration;
using Auth.Domain.UseCases.Service.Dto;
using Microsoft.AspNetCore.Mvc;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;

namespace Auth.Api.EndpointBuilders
{
    public static class ServiceEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildServiceEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapGroup("service")
                .BuildServiceInfoEndpoints();
        }
        private static IEndpointRouteBuilder BuildServiceInfoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("service-info",
                async ([FromServices] IHttpRequestHandler<ServiceInfoDto, EmptyRequest> getServiceInfoQueryHandler, CancellationToken cancellationToken) =>
                await getServiceInfoQueryHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<ServiceInfoDto>()
                    .WithName("GetServiceInfo")
                    .RequireAuthorization(AuthorizationConfiguration.UserPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }


    }
}
