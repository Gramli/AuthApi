using Auth.Core.Abstractions;
using Auth.Domain.Commands;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Database.EFContext.Entities;
using Auth.Infrastructure.Extensions;
using Auth.Infrastructure.Options;
using Auth.Infrastructure.Services;
using Mapster;
using Microsoft.EntityFrameworkCore;
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
                .RegisterMapsterConfiguration()
                .AddDatabase()
                .AddSingleton<ITokenService, TokenService>();
        }

        private static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<RegisterCommand, UserEntity>
            .NewConfig()
            .Map(dest => dest.Password, src => PasswordHasher.HashPassword(src.Password));
            return serviceCollection;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
        {
            return serviceCollection
                .AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"));
        }
    }
}
