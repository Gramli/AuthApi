namespace Auth.Infrastructure.UseCases.User.Entities
{
    internal class RoleEntity
    {
        public int Id { get; init; }
        public string Role { get; set; } = "user";
    }
}
