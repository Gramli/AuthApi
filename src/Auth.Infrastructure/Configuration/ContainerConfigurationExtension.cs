﻿using Auth.Core.Abstractions.Repositories;
using Auth.Core.Abstractions.Services;
using Auth.Domain.UseCases.User.Commands;
using Auth.Domain.UseCases.User.Dto;
using Auth.Infrastructure.Abstractions;
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
            //just for example purpose => security issue, jwt secret is NOT in app config!
            serviceCollection.Configure<TokenOptions>(configuration.GetSection("jwt"));

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
                .AddScoped<IUserQueriesRepository, UserQueriesRepository>()
                .AddScoped<ISecretUserQueriesRepository, UserQueriesRepository>()
                .AddScoped<ISecretUserCommandsRepository, UserCommandsRepository>()
                .AddScoped<IRoleQueriesRepository, RoleQueriesRepository>()
                .AddScoped<ISecretRoleQueriesRepository, RoleQueriesRepository>()
                .AddScoped<ISecretRoleCommandRepository, RoleCommandRepository>()
                .AddScoped<IUserCommandsRepository, UserCommandsRepository>();
    }
}
