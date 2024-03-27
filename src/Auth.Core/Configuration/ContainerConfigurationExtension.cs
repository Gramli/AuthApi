using Auth.Core.Abstractions.Commands;
using Auth.Core.Abstractions.Queries;
using Auth.Core.Commands;
using Auth.Core.Extensions;
using Auth.Core.Queries;
using Auth.Core.Validation;
using Auth.Domain.Commands;
using Microsoft.Extensions.DependencyInjection;
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
                .AddScoped<ILoginCommandHandler, LoginCommandHandler>()
                .AddScoped<IRegisterCommandHandler, RegisterCommandHandler>()
                .AddScoped<IChangeRoleCommandHandler, ChangeRoleCommandHandler>()
                .AddScoped<IGetUserInfoQueryHandler, GetUserInfoQueryHandler>()
                .AddScoped<IGetServiceInfoQueryHandler, GetServiceInfoQueryHandler>();

        private static IServiceCollection AddCoreValidation(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddValidotSingleton<IValidator<ChangeRoleCommand>, ChangeRoleCommandSpecificationHolder, ChangeRoleCommand>()
                .AddValidotSingleton<IValidator<RegisterCommand>, RegisterCommandSpecificationHolder, RegisterCommand>()
                .AddValidotSingleton<IValidator<LoginCommand>, LoginCommandSpecificationHandler, LoginCommand>();
    }
}
