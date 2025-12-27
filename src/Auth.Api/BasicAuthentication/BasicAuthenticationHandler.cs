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
                return AuthenticateResult.Fail("Unauthorized"); ;
            }

            var authHeader = AuthenticationHeaderValue.Parse(authorizationHeader);
            var credentialBytes = Convert.FromBase64String(authHeader.Parameter ?? string.Empty);
            var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':', 2);
            var username = credentials[0];
            if (credentials.Length != 2 || username != this.Options.UserName || credentials[1] != this.Options.Password)
            {
                return AuthenticateResult.Fail("Forbidden");
            }

            var claims = new List<Claim>()
        {
            new("Username", username),
            new("Role", "Administrator")
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
