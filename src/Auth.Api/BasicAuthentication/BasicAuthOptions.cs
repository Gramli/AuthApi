using Microsoft.AspNetCore.Authentication;

namespace Auth.Api.BasicAuthentication
{
    public sealed class BasicAuthOptions : AuthenticationSchemeOptions
    {
        public string UserName { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
