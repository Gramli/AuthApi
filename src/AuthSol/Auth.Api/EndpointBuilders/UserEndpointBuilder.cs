using Auth.Api.Extensions;
using Auth.Core.Abstractions.Commands;
using Auth.Domain.Commands;
using Auth.Domain.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Auth.Api.EndpointBuilders
{
    public static class UserEndpointBuilder
    {
        public static IEndpointRouteBuilder BuildUserEndpoints(this IEndpointRouteBuilder endpointRouteBuilder)
        {
            endpointRouteBuilder.MapPost("/login",
                [AllowAnonymous] async (LoginCommand loginCommand, [FromServices] ILoginCommandHandler loginCommandHandler, CancellationToken cancellationToken) =>
                await loginCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<LogedUserDto>()
                    .WithName("Login");

            endpointRouteBuilder.MapPost("/register",
                [AllowAnonymous] async (RegisterCommand loginCommand, [FromServices] IRegisterCommandHandler registerCommandHandler, CancellationToken cancellationToken) =>
                await registerCommandHandler.SendAsync(loginCommand, cancellationToken))
                    .Produces<LogedUserDto>()
                    .WithName("Register");

            //TODO ADD ENDPOINT FOR EDITING USER ROLES FOR ADMIN 

            return endpointRouteBuilder;
        }
    }
}
