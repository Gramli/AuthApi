using Ardalis.GuardClauses;
using Auth.Infrastructure.Abstractions;
using Auth.Infrastructure.Database.EFContext.Entities;
using Auth.Infrastructure.Extensions;
using Microsoft.Extensions.DependencyInjection;

namespace Auth.Api.Configuration
{
    public static class UsersConfiguration
    {
        public static async Task AddDefaultUsers(this IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var secretUserCommandsRepository = scope.ServiceProvider.GetRequiredService<ISecretUserCommandsRepository>();
            Guard.Against.Null(secretUserCommandsRepository);

            var admin = new UserEntity()
            {
                Email = "noEmail",
                Password = PasswordHasher.HashPassword("passwAdmin"),
                Username = "admin",
                Role = "administrator",
            };

            await secretUserCommandsRepository.AddUser(admin, CancellationToken.None);
        }
    }
}
