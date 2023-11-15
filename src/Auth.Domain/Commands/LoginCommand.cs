namespace Auth.Domain.Commands
{
    public class LoginCommand(string username, string password)
    {
        public string Username { get; init; } = username;
        public string Password { get; init; } = password;
    }
}
