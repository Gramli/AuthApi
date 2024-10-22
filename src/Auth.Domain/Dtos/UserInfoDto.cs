namespace Auth.Domain.Dtos
{
    public sealed class UserInfoDto(string userName, string role, string email) : UserDto(userName, role)
    {
        public string Email { get; init; } = email;
    }
}
