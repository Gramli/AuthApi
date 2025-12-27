using Auth.Api.BasicAuthentication;
using Auth.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;

namespace Auth.Api.Configuration
{
public static class AuthorizationConfiguration
{
    public static readonly string BasicPolicyName = "basicPolicy";
    public static readonly string UserPolicyName = "userPolicy";
    public static readonly string DeveloperPolicyName = "developerPolicy";
    public static readonly string AdministratorPolicyName = "administratorPolicy";

    public static IServiceCollection ConfigureAuthorization(this IServiceCollection serviceCollection)
    {
        serviceCollection.AddAuthorization(options =>
        {
            options.AddBearerPolicy(UserPolicyName, AuthRoles.AllRoles);
            options.AddBearerPolicy(DeveloperPolicyName, [AuthRoles.Developer, AuthRoles.Administrator]);
            options.AddBearerPolicy(AdministratorPolicyName, [AuthRoles.Administrator]);
            options.AddPolicy(BasicPolicyName, options =>
            {
                options.RequireAuthenticatedUser();
                options.AddAuthenticationSchemes(BasicSchemeDefaults.AuthenticationScheme);
            });
        });

        return serviceCollection;
    }

    public static void AddBearerPolicy(this AuthorizationOptions authorizationOptions, string policyName, IEnumerable<string> roles)
    {
        authorizationOptions.AddPolicy(policyName, policy =>
        {
            policy.RequireAuthenticatedUser();
            policy.AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme);
            policy.RequireRole(roles);

        });
    }
}
}
