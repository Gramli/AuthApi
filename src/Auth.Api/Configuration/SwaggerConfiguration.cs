using Auth.Api.BasicAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi;

namespace Auth.Api.Configuration
{
    public static class SwaggerConfiguration
    {
        private static readonly string _version = "v1";
        public static IServiceCollection ConfigureSwagger(this IServiceCollection serviceCollection)
        {
            return serviceCollection.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(_version, CreateInfo());
                options.AddSecurityDefinition(JwtBearerDefaults.AuthenticationScheme, CreateScheme());
                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference(JwtBearerDefaults.AuthenticationScheme, document)] = []
                });
                options.AddSecurityDefinition(BasicSchemeDefaults.AuthenticationScheme, CreateBasicScheme());
                options.AddSecurityRequirement(document => new OpenApiSecurityRequirement
                {
                    [new OpenApiSecuritySchemeReference(BasicSchemeDefaults.AuthenticationScheme, document)] = []
                });
            });
        }

        private static OpenApiSecurityScheme CreateScheme()
        {
            return new OpenApiSecurityScheme()
            {
                Name = "JWT Bearer token",
                Type = SecuritySchemeType.Http,
                Scheme = JwtBearerDefaults.AuthenticationScheme,
                BearerFormat = "JWT",
                Description = "JWT Bearer token Authorization",
            };
        }

        private static OpenApiSecurityScheme CreateBasicScheme()
        {
            return new OpenApiSecurityScheme()
            {
                Name = "Basic Authorization",
                Type = SecuritySchemeType.Http,
                Scheme = BasicSchemeDefaults.AuthenticationScheme,
                In = ParameterLocation.Header,
                Description = "Enter your username and password.",
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
