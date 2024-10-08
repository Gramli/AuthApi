using Auth.Api.Configuration;
using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Queries;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Microsoft.AspNetCore.Mvc;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.Response;

namespace Auth.Api.EndpointBuilders
{
    public static class UserEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildUserEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapGroup("user")
                .BuildUserAuthEndpoints()
                .BuildUserChangeEndpoints()
                .BuildUserInfoEndpoints();
        }
        private static IEndpointRouteBuilder BuildUserAuthEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("login",
                async (LoginCommand loginCommand, [FromServices] ILoginCommandHandler loginCommandHandler, CancellationToken cancellationToken) =>
                await loginCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<string>()
                    .WithName("Login")
                    .AllowAnonymous()
                    .WithOpenApi();

            endpointRouteBuilder.MapPost("register",
                async (RegisterCommand loginCommand, [FromServices] IRegisterCommandHandler registerCommandHandler, CancellationToken cancellationToken) =>
                await registerCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<bool>()
                    .WithName("Register")
                    .AllowAnonymous()
                    .WithOpenApi();

            return endpointRouteBuilder;
        }

        private static IEndpointRouteBuilder BuildUserChangeEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("changeRole",
                async (ChangeRoleCommand changeRoleCommand, [FromServices] IChangeRoleCommandHandler changeRoleCommandHandler, CancellationToken cancellationToken) =>
                await changeRoleCommandHandler.SendAsync(changeRoleCommand, cancellationToken))
                    .Produces<bool>()
                    .WithName("ChangeRole")
                    .RequireAuthorization(AuthorizationConfiguration.AdministratorPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }

        private static IEndpointRouteBuilder BuildUserInfoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("getUsersInfo",
                async ([FromServices] IGetUserInfoQueryHandler getUserInfoCommandHandler, CancellationToken cancellationToken) =>
                await getUserInfoCommandHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<IEnumerable<UserDto>>()
                    .WithName("GetUsersInfo")
                    .RequireAuthorization(AuthorizationConfiguration.DeveloperPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }


    }
}
