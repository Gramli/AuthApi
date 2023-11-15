namespace Auth.Domain.Dtos
{
    public class LoggedUserDto(string userName, string role, string jwtToken) : UserDto(userName, role)
    {
        public string JwtToken { get; init; } = jwtToken;
    }
}
