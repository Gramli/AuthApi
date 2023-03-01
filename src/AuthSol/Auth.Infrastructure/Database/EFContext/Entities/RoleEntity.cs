namespace Auth.Infrastructure.Database.EFContext.Entities
{
    internal class RoleEntity
    {
        public int Id { get; init; }
        public string Role { get; set; } = "user";
        public virtual ICollection<UserEntity> Users { get; set; }
    }
}
