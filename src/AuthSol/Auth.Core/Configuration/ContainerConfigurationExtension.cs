using Auth.Core.Abstractions.Commands;
using Auth.Core.Commands;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Core.Configuration
{
    public static class ContainerConfigurationExtension
    {
        public static IServiceCollection AddCore(this IServiceCollection serviceCollection, IConfiguration configuration)
            => serviceCollection
                .AddScoped<ILoginCommandHandler, LoginCommandHandler>()
                .AddScoped<IRegisterCommandHandler, RegisterCommandHandler>();
    }
}
