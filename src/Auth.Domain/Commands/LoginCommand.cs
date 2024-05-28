namespace Auth.Domain.Commands
{
    public sealed class LoginCommand(string username, string password)
    {
        public string Username { get; init; } = username;
        public string Password { get; init; } = password;
    }
}
