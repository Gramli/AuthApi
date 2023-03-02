namespace Auth.Domain.Dtos
{
    public class UserDto
    {
        public string Username { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;

        public UserDto()
        {

        }
        public UserDto(string userName, string role)
        {
            Username = userName;
            Role = role;
        }
    }
}
