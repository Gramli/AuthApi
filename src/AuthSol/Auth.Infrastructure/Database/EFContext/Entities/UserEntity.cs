namespace Auth.Infrastructure.Database.EFContext.Entities
{
    internal class UserEntity
    {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string Password { get; init; } = string.Empty;
        public string Email { get; init; } = string.Empty;
        public string Role { get; set; } = "user";
    }
}
