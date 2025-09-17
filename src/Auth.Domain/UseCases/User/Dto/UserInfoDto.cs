namespace Auth.Domain.UseCases.User.Dto
{
    public sealed class UserInfoDto(int id, string userName, string role, string email) : UserDto(id, userName, role)
    {
        public string Email { get; init; } = email;
    }
}
