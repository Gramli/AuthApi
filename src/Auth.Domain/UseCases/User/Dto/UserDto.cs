namespace Auth.Domain.UseCases.User.Dto
{
    public class UserDto
    {
        public int Id { get; init; }
        public string Username { get; init; } = string.Empty;
        public string Role { get; init; } = string.Empty;

        public UserDto()
        {

        }
        public UserDto(int id, string userName, string role)
        {
            Id = id;
            Username = userName;
            Role = role;
        }
    }
}
