using Ardalis.GuardClauses;
using System.Security.Claims;

namespace Auth.Api.Midllewares
{
    public class ClaimsMiddleware(RequestDelegate next)
    {
        private readonly RequestDelegate _next = Guard.Against.Null(next);

        public async Task InvokeAsync(HttpContext context)
        {

            if(context.User.Identity is not null &&  context.User.Identity.IsAuthenticated)
            {
                var customClaims = new List<Claim> { new(ClaimTypes.UserData, "someUserData") };
                context.User.AddIdentity(new ClaimsIdentity(customClaims));
            }

            await _next(context);
        }
    }
}
