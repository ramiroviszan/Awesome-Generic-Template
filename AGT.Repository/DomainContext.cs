using AGT.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace AGT.Repository
{
    public class DomainContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DomainContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
     
            modelBuilder.Entity<User>().Property(u => u.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<User>().HasKey(u => u.Id);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Username);
            modelBuilder.Entity<User>().HasAlternateKey(u => u.Email);

            modelBuilder.Entity<Rol>().Property(r => r.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Rol>().HasKey(r => r.Id);
            modelBuilder.Entity<DefaultRol>().HasBaseType<Rol>();

            modelBuilder.Entity<Feature>().HasKey(f => f.Id);
            modelBuilder.Entity<Feature>().HasAlternateKey(f => new { f.Name, f.Value });
        }
    }
}