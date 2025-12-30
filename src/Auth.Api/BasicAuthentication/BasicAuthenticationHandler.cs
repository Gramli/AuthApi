using Auth.Domain;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Options;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;

namespace Auth.Api.BasicAuthentication
{
    public sealed class BasicAuthenticationHandler : AuthenticationHandler<BasicAuthOptions>
    {
        public BasicAuthenticationHandler(
            IOptionsMonitor<BasicAuthOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder)
            : base(options, logger, encoder)
        {
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out var authorizationHeader))
            {
                return AuthenticateResult.Fail("Missing Authorization header");
            }

            if (!AuthenticationHeaderValue.TryParse(authorizationHeader.ToString(), out var authHeader))
            {
                return AuthenticateResult.Fail("Invalid Authorization header");
            }

            if (string.IsNullOrEmpty(authHeader?.Parameter))
            {
                return AuthenticateResult.Fail("Missing Authorization Header parameter");
            }

            Span<byte> bytesBuffer = stackalloc byte[authHeader!.Parameter!.Length];
            if (!Convert.TryFromBase64String(authHeader.Parameter, bytesBuffer, out var bytesWritten))
            {
                return AuthenticateResult.Fail("Invalid Base64 string");
            }

            var credentials = Encoding.UTF8.GetString(bytesBuffer[..bytesWritten]).Split(':', 2);

            if (credentials.Length != 2)
            {
                return AuthenticateResult.Fail("Invalid credential format");
            }

            if (credentials[0] != this.Options.UserName || credentials[1] != this.Options.Password)
            {
                return AuthenticateResult.Fail("Invalid credentials");
            }

            var claims = new List<Claim>()
            {
                new(ClaimTypes.Name, credentials[0]),
                new(ClaimTypes.Role, AuthRoles.Administrator)
            };

            var claimsIdentity = new ClaimsIdentity(claims, Scheme.Name);
            var claimsPrincipal = new ClaimsPrincipal(claimsIdentity);

            return AuthenticateResult.Success(
                new AuthenticationTicket(
                    claimsPrincipal,
                    Scheme.Name));
        }
    }
}
