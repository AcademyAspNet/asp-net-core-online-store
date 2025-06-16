using Microsoft.EntityFrameworkCore;
using OnlineStore.Data.Models;

namespace OnlineStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                        .Property(product => product.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<Review>()
                        .Property(review => review.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");

            modelBuilder.Entity<User>()
                        .Property(user => user.CreatedAt)
                        .HasDefaultValueSql("GETDATE()");
        }
    }
}
