using Microsoft.OpenApi;

namespace Auth.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        private static readonly string _bearer = "Bearer";
        private static readonly string _version = "v1";
        public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_version, CreateInfo());
                options.AddSecurityDefinition(_bearer, CreateScheme());
                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference(_bearer, document)] = []
                });
            });
        }

        private static OpenApiSecurityScheme CreateScheme()
        {
            return new OpenApiSecurityScheme()
            {
                Name = "JWT Bearer token",
                Type = SecuritySchemeType.Http,
                Scheme = _bearer,
                BearerFormat = "JWT",
                Description = "JWT Bearer token Authorization",
            };
        }

        private static OpenApiInfo CreateInfo()
        {
            return new OpenApiInfo()
            {
                Version = _version,
            };
        }
    }
}
