using AGT.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AGT.Repository
{
    public class RepositoryContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<IRol> Roles { get; set; }

        protected RepositoryContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<IRol>().Property("Id").ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasKey("Id");
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Username);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);
            modelBuilder.Entity<IRol>().Property("Id").ValueGeneratedOnAdd();
        }
    }
}