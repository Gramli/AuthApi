namespace Auth.Infrastructure.UseCases.User.Entities
{
    internal class UserEntity
    {
        public int Id { get; init; }
        public required string Username { get; init; }
        public required string Password { get; init; }
        public required string Email { get; init; }
        public required RoleEntity Role { get; set; }
    }
}
