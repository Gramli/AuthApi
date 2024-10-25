using Auth.Api.Configuration;
using Auth.Domain;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Microsoft.AspNetCore.Mvc;
using SmallApiToolkit.Core.Extensions;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using System.Net;

namespace Auth.Api.EndpointBuilders
{
    public static class UserEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildUserEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            return endpointRouteBuilder
                .MapGroup("user")
                .BuildUserAuthEndpoints()
                .BuildUserRoleEndpoints()
                .BuildUserInfoEndpoints();
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

            endpointRouteBuilder.MapPost("register",
                async (RegisterCommand loginCommand, [FromServices] IHttpRequestHandler<bool, RegisterCommand> registerCommandHandler, CancellationToken cancellationToken) =>
                await registerCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<bool>()
                    .WithName("Register")
                    .AllowAnonymous()
                    .WithOpenApi();

            return endpointRouteBuilder;
        }

        private static IEndpointRouteBuilder BuildUserRoleEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("change-role",
                async (ChangeRoleCommand changeRoleCommand, [FromServices] IHttpRequestHandler<bool, ChangeRoleCommand> changeRoleCommandHandler, CancellationToken cancellationToken) =>
                await changeRoleCommandHandler.SendAsync(changeRoleCommand, cancellationToken))
                    .Produces<bool>()
                    .WithName("ChangeRole")
                    .RequireAuthorization(AuthorizationConfiguration.AdministratorPolicyName)
                    .WithOpenApi();

            endpointRouteBuilder.MapGet("get-roles",
                (CancellationToken cancellationToken) =>
                Results.Json((DataResponse<IEnumerable<string>>)HttpDataResponses.AsOK(AuthRoles.AllRoles), statusCode: (int)HttpStatusCode.OK))
                    .Produces<bool>()
                    .WithName("GetRoles")
                    .RequireAuthorization(AuthorizationConfiguration.AdministratorPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }

        private static IEndpointRouteBuilder BuildUserInfoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("users-info",
                async ([FromServices] IHttpRequestHandler<IEnumerable<UserDto>, EmptyRequest> getUserInfoCommandHandler, CancellationToken cancellationToken) =>
                await getUserInfoCommandHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<IEnumerable<UserDto>>()
                    .WithName("GetUsersInfo")
                    .RequireAuthorization(AuthorizationConfiguration.DeveloperPolicyName)
                    .WithOpenApi();

            endpointRouteBuilder.MapGet("user-info",
                async ([FromServices] IHttpRequestHandler<UserInfoDto, EmptyRequest> getUserInfoCommandHandler, CancellationToken cancellationToken) =>
                await getUserInfoCommandHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<IEnumerable<UserInfoDto>>()
                    .WithName("GetUserInfo")
                    .RequireAuthorization(AuthorizationConfiguration.UserPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }


    }
}
