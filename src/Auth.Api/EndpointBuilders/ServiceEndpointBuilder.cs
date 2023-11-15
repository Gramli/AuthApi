using Auth.Api.Configuration;
using Auth.Api.Extensions;
using Auth.Core.Abstractions.Queries;
using Auth.Domain.Dtos;
using Auth.Domain.Http;
using Microsoft.AspNetCore.Mvc;

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
            endpointRouteBuilder.MapGet("v1/getServiceInfo",
                async ([FromServices] IGetServiceInfoQueryHandler getServiceInfoQueryHandler, CancellationToken cancellationToken) =>
                await getServiceInfoQueryHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<ServiceInfoDto>()
                    .WithName("GetServiceInfo")
                    .RequireAuthorization(AuthorizationConfiguration.UserPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }


    }
}
