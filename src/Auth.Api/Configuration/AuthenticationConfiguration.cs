using Ardalis.GuardClauses;
using Auth.Api.BasicAuthentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Auth.Api.Configuration
{
    public static class AuthenticationConfiguration
    {
        public static IServiceCollection ConfigureAuthentication(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var jwtKey = Guard.Against.NullOrEmpty(configuration["Authentication:Schemes:Bearer:Key"]);

            serviceCollection.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
            {
                options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtKey));
                options.TokenValidationParameters.ValidateIssuerSigningKey = true;
            }).AddScheme<BasicAuthOptions, BasicAuthenticationHandler>(BasicSchemeDefaults.AuthenticationScheme, (options) =>
            {
                options.UserName = configuration["Authentication:Schemes:Basic:UserName"] ?? string.Empty;
                options.Password = configuration["Authentication:Schemes:Basic:Password"] ?? string.Empty;
            });

            return serviceCollection;
        }
    }
}
