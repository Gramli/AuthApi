using Auth.Core.Extensions;
using Auth.Core.UseCases.Service;
using Auth.Core.UseCases.User.Commands;
using Auth.Core.UseCases.User.Queries;
using Auth.Core.UseCases.User.Validation;
using Auth.Domain.UseCases.Service.Dto;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Microsoft.Extensions.DependencyInjection;
using SmallApiToolkit.Core.RequestHandlers;
using SmallApiToolkit.Core.Response;
using Validot;

namespace Auth.Core.Configuration
{
    public static class ContainerConfigurationExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddCoreHandlers()
                .AddCoreValidation();

        private static IServiceCollection AddCoreHandlers(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddScoped<IHttpRequestHandler<string, LoginCommand>, LoginCommandHandler>()
                .AddScoped<IHttpRequestHandler<bool, RegisterCommand>, RegisterCommandHandler>()
                .AddScoped<IHttpRequestHandler<bool, ChangeRoleCommand>, ChangeRoleCommandHandler>()
                .AddScoped<IHttpRequestHandler<IEnumerable<UserDto>, EmptyRequest>, GetUsersInfoQueryHandler>()
                .AddScoped<IHttpRequestHandler<ServiceInfoDto, EmptyRequest>, GetServiceInfoQueryHandler>()
                .AddScoped<IHttpRequestHandler<UserInfoDto, EmptyRequest>, GetUserInfoQueryHandler>();

        private static IServiceCollection AddCoreValidation(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddValidotSingleton<IValidator<ChangeRoleCommand>, ChangeRoleCommandSpecificationHolder, ChangeRoleCommand>()
                .AddValidotSingleton<IValidator<RegisterCommand>, RegisterCommandSpecificationHolder, RegisterCommand>()
                .AddValidotSingleton<IValidator<LoginCommand>, LoginCommandSpecificationHandler, LoginCommand>();
    }
}
