using Auth.Infrastructure.Database.EFContext.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.Infrastructure.Database.EFContext
{
    //TODO ADD ADMIN USER PROGRAMICALLY
    internal class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options)
            : base(options) { }

        public virtual DbSet<UserEntity> Users => Set<UserEntity>();
    }
}
