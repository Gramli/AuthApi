using Auth.Domain.Commands;
using Microsoft.AspNetCore.Authorization;

namespace Auth.Api.EndpointBuilders
{
    public static class LoginEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildLoginEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("/login", [AllowAnonymous](LoginCommand loginCommand) =>
            {

            });

            return endpointRouteBuilder;
        }
    }
}
