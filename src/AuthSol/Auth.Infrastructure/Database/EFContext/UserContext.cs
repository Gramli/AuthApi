using Auth.Infrastructure.Database.EFContext.Entities;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace Auth.Infrastructure.Database.EFContext
{
    internal class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>()
            .HasOne(s => s.Role)
            .WithMany(s=>s.Users);
        }

        public virtual DbSet<UserEntity> Users => Set<UserEntity>();
        public virtual DbSet<RoleEntity> Roles => Set<RoleEntity>();
    }
}
