using Auth.Domain;

namespace Auth.Api.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static readonly string UserPolicyName = "userPolicy";
        public static readonly string DeveloperPolicyName = "developerPolicy";
        public static readonly string AdministratorPolicyName = "administratorPolicy";

        public static IServiceCollection ConfigureAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy(UserPolicyName, policy => policy.RequireRole(AuthRoles.AllRoles));
                options.AddPolicy(DeveloperPolicyName, policy => policy.RequireRole(AuthRoles.Developer, AuthRoles.Administrator));
                options.AddPolicy(AdministratorPolicyName, policy => policy.RequireRole(AuthRoles.Administrator));
            });

            return serviceCollection;
        }
    }
}
