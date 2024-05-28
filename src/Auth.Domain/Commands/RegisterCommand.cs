namespace Auth.Domain.Commands
{
    public sealed class RegisterCommand(string username, string password, string email)
    {
        public string Username { get; init; } = username;
        public string Password { get; init; } = password;
        public string Email { get; init; } = email;
    }
}
