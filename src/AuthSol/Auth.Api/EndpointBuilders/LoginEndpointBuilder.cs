using Auth.Domain.Commands;

namespace Auth.Api.EndpointBuilders
{
    public static class LoginEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildLoginEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("/login", (LoginCommand loginCommand) =>
            {

            });

            return endpointRouteBuilder;
        }
    }
}
