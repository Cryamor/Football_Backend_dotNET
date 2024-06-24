using Microsoft.EntityFrameworkCore;
using User.Models;

namespace User.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        public DbSet<UserEntity> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 配置模型关系等
        }
    }
}