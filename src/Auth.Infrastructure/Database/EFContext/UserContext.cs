using Auth.Infrastructure.UseCases.User.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database.EFContext
{
    internal class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        public virtual DbSet<UserEntity> Users => Set<UserEntity>();
        public virtual DbSet<RoleEntity> Roles => Set<RoleEntity>();
    }
}
