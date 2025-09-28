namespace Auth.Api.Configuration
{
    internal static class HttpResponseCachingConfiguration
    {
        private static readonly int Hour = 60 * 60;

        public static RouteHandlerBuilder AddResponseCacheHourPolicy(this RouteHandlerBuilder routeHandlerBuilder)
            => routeHandlerBuilder.AddResponseCachePolicy(Hour);

        public static RouteHandlerBuilder AddResponseCachePolicy(this RouteHandlerBuilder routeHandlerBuilder, int maxAgeInSeconds)
            => routeHandlerBuilder.AddEndpointFilter(async (context, next) =>
            {
                context.HttpContext.Response.Headers["Cache-Control"] = $"public,max-age={maxAgeInSeconds}";
                return await next(context);
            });
    }
}
