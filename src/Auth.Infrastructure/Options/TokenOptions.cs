namespace Auth.Infrastructure.Options
{
    internal sealed class TokenOptions
    {
        public string Key { get; init; } = string.Empty;
        public int ExpirationInMinutes {  get; init; }
    }
}
