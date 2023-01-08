namespace Auth.Api.Configuration
{
    public static class AuthorizationConfiguration
    {
        public static IServiceCollection ConfigureAuthorization(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddAuthorization(options =>
            {
                options.AddPolicy("user", policy => policy.RequireRole("user"));
                options.AddPolicy("developer", policy => policy.RequireRole("developer"));
                options.AddPolicy("administrator", policy => policy.RequireRole("administrator"));
            });

            return serviceCollection;
        }
    }
}
