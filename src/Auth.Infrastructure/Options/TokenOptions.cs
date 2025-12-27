namespace Auth.Infrastructure.Options
{
    internal sealed class TokenOptions
    {
        public required string Key { get; set; }
        public required int ExpirationInMinutes {  get; set; }
        public required string Issuer { get; set; }
        public required string Audience { get; set; }
    }
}
