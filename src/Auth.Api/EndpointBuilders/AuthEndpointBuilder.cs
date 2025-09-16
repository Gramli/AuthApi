using Auth.Api.Configuration;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Microsoft.AspNetCore.Mvc;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;

namespace Auth.Api.EndpointBuilders
{
    public static class AuthEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildAuthEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapGroup("auth")
                .BuildUserAuthEndpoints();
        }
        private static IEndpointRouteBuilder BuildUserAuthEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("login",
                async (LoginCommand loginCommand, [FromServices] IHttpRequestHandler<string, LoginCommand> loginCommandHandler, CancellationToken cancellationToken) =>
                await loginCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<string>()
                    .WithName("Login")
                    .AllowAnonymous()
                    .WithOpenApi();

            endpointRouteBuilder.MapGet("/user",
                async ([FromServices] IHttpRequestHandler<UserInfoDto, EmptyRequest> getUserInfoCommandHandler, CancellationToken cancellationToken) =>
                await getUserInfoCommandHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<IEnumerable<UserInfoDto>>()
                    .WithName("UserInfo")
                    .WithOpenApi();

            endpointRouteBuilder.MapPost("register",
                async (RegisterCommand loginCommand, [FromServices] IHttpRequestHandler<bool, RegisterCommand> registerCommandHandler, CancellationToken cancellationToken) =>
                await registerCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<bool>()
                    .WithName("Register")
                    .AllowAnonymous()
                    .WithOpenApi();

            return endpointRouteBuilder;
        }
    }
}
