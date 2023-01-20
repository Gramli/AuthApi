namespace Auth.Infrastructure.Options
{
    internal sealed class TokenOptions
    {
        public string JwtKey { get; init; } = string.Empty;
    }
}
