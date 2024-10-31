using Ardalis.GuardClauses;
using Auth.Domain;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Extensions;
using Auth.Infrastructure.UseCases.User.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Infrastructure.Configuration
{
    public static class UsersConfiguration
    {
        public static async Task AddDefaultRoles(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var secretRoleCommandRepository = scope.ServiceProvider.GetRequiredService<ISecretRoleCommandRepository>();
            Guard.Against.Null(secretRoleCommandRepository);
            await secretRoleCommandRepository.AddRoles(AuthRoles.AllRoles, CancellationToken.None);
        }

        public static async Task AddDefaultUsers(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var secretUserCommandsRepository = scope.ServiceProvider.GetRequiredService<ISecretUserCommandsRepository>();
            var secretRoleQueriesRepository = scope.ServiceProvider.GetRequiredService<ISecretRoleQueriesRepository>();
            Guard.Against.Null(secretUserCommandsRepository);
            Guard.Against.Null(secretRoleQueriesRepository);

            var roles = await secretRoleQueriesRepository.GetRoleEntities(CancellationToken.None);

            var admin = new UserEntity()
            {
                Email = "noEmail",
                Password = PasswordHasher.HashPassword("admin"),
                Username = "admin",
                Role = roles.Single(x => x.Role.Equals(AuthRoles.Administrator, StringComparison.OrdinalIgnoreCase))
            };

            await secretUserCommandsRepository.AddUser(admin, CancellationToken.None);
        }
    }
}
