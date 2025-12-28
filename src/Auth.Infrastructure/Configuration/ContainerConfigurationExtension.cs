using Ardalis.GuardClauses;
using Auth.Core.Abstractions.Services;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Auth.Infrastructure.Database.EFContext;
using Auth.Infrastructure.Extensions;
using Auth.Infrastructure.Options;
using Auth.Infrastructure.Services;
using Auth.Infrastructure.UseCases.User.Entities;
using Auth.Infrastructure.UseCases.User.Repositories;
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
            serviceCollection.Configure<TokenOptions>(options =>
            {
                var bearerSection = configuration.GetSection("Authentication:Schemes:Bearer");
                options.Key = Guard.Against.Null(bearerSection["Key"]);
                options.ExpirationInMinutes = Guard.Against.Null(bearerSection.GetValue<int>("ExpirationInMinutes"));
                options.Issuer = Guard.Against.Null(bearerSection["ValidIssuer"]);
                options.Audience = Guard.Against.Null(bearerSection.GetSection("ValidAudiences").Get<string[]>()?.FirstOrDefault());
            });

            return serviceCollection
                .RegisterMapsterConfiguration()
                .AddDatabase()
                .AddServices();
        }

        private static IServiceCollection AddServices(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddSingleton<ITokenService, TokenService>()
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IUserService, UserService>();

        private static IServiceCollection RegisterMapsterConfiguration(this IServiceCollection serviceCollection)
        {
            TypeAdapterConfig<RegisterCommand, UserEntity>
            .NewConfig()
            .Map(dest => dest.Password, src => PasswordHasher.HashPassword(src.Password));

            TypeAdapterConfig<UserEntity, UserDto>
            .NewConfig()
            .Map(dest => dest.Role, src => src.Role.Role);

            return serviceCollection;
        }

        private static IServiceCollection AddDatabase(this IServiceCollection serviceCollection)
            => serviceCollection
                .AddDbContext<UserContext>(opt => opt.UseInMemoryDatabase("Users"))
                .AddScoped<Abstractions.IUserQueriesRepository, UserQueriesRepository>()
                .AddScoped<Core.Abstractions.Repositories.IUserQueriesRepository, UserQueriesRepository>()
                .AddScoped<Abstractions.IUserCommandsRepository, UserCommandsRepository>()
                .AddScoped<Abstractions.IRoleQueriesRepository, RoleQueriesRepository>()
                .AddScoped<Core.Abstractions.Repositories.IRoleQueriesRepository, RoleQueriesRepository>()
                .AddScoped<Abstractions.IRoleCommandRepository, RoleCommandRepository>()
                .AddScoped<Abstractions.IUserCommandsRepository, UserCommandsRepository>();
    }
}
