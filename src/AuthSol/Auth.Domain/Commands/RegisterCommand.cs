namespace Auth.Domain.Commands
{
    public class RegisterCommand
    {
        public string Username { get; init; }
        public string Password { get; init; }
        public string Email { get; init; }

        public RegisterCommand(string username, string password, string email)
        {
            Username = username;
            Password = password;
            Email = email;
        }
    }
}
