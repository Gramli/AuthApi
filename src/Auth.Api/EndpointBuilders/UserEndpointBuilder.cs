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
                .MapGroup("users")
                .BuildUserRoleEndpoints()
                .BuildUserInfoEndpoints();
        }

        private static IEndpointRouteBuilder BuildUserRoleEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPatch("/{id}/role",
                async (int id, ChangeRoleBody changeRoleCommand, [FromServices] IHttpRequestHandler<bool, ChangeRoleCommand> changeRoleCommandHandler, CancellationToken cancellationToken) =>
                await changeRoleCommandHandler.SendAsync(new ChangeRoleCommand { Id = id, RoleName = changeRoleCommand.RoleName}, cancellationToken))
                    .Produces<bool>()
                    .WithName("ChangeRole")
                    .RequireAuthorization(AuthorizationConfiguration.AdministratorPolicyName)
                    .WithOpenApi();

            endpointRouteBuilder.MapGet("/roles",
                () =>
                Results.Json((DataResponse<IEnumerable<string>>)HttpDataResponses.AsOK(AuthRoles.AllRoles), statusCode: (int)HttpStatusCode.OK))
                    .Produces<bool>()
                    .WithName("GetRoles")
                    .RequireAuthorization(AuthorizationConfiguration.AdministratorPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }

        private static IEndpointRouteBuilder BuildUserInfoEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapGet("/",
                async ([FromServices] IHttpRequestHandler<IEnumerable<UserDto>, EmptyRequest> getUserInfoCommandHandler, CancellationToken cancellationToken) =>
                await getUserInfoCommandHandler.SendAsync(EmptyRequest.Instance, cancellationToken))
                    .Produces<IEnumerable<UserDto>>()
                    .WithName("GetUsersInfo")
                    .RequireAuthorization(AuthorizationConfiguration.DeveloperPolicyName)
                    .WithOpenApi();

            return endpointRouteBuilder;
        }


    }
}
