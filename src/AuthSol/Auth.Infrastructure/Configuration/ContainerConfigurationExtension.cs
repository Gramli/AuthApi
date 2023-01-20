using Auth.Core.Abstractions;
using Auth.Infrastructure.Options;
using Auth.Infrastructure.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configuration
{
    public static class ContainerConfigurationExtension
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //just for example purpose => security issue, jwt secret is NOT in app config!
            serviceCollection.Configure<TokenOptions>(configuration.GetSection("jwt"));

            return serviceCollection
                .AddSingleton<ITokenService, TokenService>();
        }
    }
}
