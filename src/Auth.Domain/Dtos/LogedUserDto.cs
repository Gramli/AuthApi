namespace Auth.Domain.Dtos
{
    public class LogedUserDto : UserDto
    {
        public string JwtToken { get; init; }

        public LogedUserDto(string userName, string role, string jwtToken)
            : base(userName, role)
        { 
            JwtToken = jwtToken;
        }
    }
}
