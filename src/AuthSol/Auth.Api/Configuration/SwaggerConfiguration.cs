using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

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
                options.AddSecurityRequirement(CreateRequirement());
            });
        }

        private static OpenApiSecurityScheme CreateScheme()
        {
            return new OpenApiSecurityScheme()
            {
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey,
                Scheme = _bearer,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JSON Web Token",
            };
        }

        private static OpenApiSecurityRequirement CreateRequirement()
        {
            return new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = _bearer
                        }
                    },
                    new string[] {}
                }
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
