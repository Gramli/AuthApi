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
                Name = "JWT Bearer token",
                Type = SecuritySchemeType.Http,
                Scheme = _bearer,
                BearerFormat = "JWT",
                In = ParameterLocation.Header,
                Description = "JWT Bearer token Authorization",
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
                        },
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
