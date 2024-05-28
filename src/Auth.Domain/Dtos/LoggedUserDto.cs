namespace Auth.Domain.Dtos
{
    public sealed class LoggedUserDto(string userName, string role, string jwtToken) : UserDto(userName, role)
    {
        public string JwtToken { get; init; } = jwtToken;
    }
}
