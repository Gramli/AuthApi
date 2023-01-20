namespace Auth.Domain.Dtos
{
    public class UserDto
    {
        public string Username { get; init; }
        public string Role { get; init; }

        public UserDto(string userName, string role)
        {
            Username = userName;
            Role = role;
        }
    }
}
