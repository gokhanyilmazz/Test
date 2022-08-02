using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace Test.Data
{
    public class TestContext:DbContext
    {              
        public TestContext(DbContextOptions<TestContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // configures one-to-many relationship
            modelBuilder.Entity<Comment>()
                .HasOne<Seller>(b => b.Seller)
                .WithMany(a => a.Comments)
                .HasForeignKey(b => b.SellerId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Comment>()
               .HasOne<User>(b => b.User)
               .WithMany(a => a.Comments)
               .HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<Order>()
               .HasOne<User>(b => b.User)
               .WithMany(a => a.Orders)
               .HasForeignKey(b => b.UserId).OnDelete(DeleteBehavior.ClientSetNull);
        }
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserType> UserTypes { get; set; } 
        public virtual DbSet<Product> Products { get; set; } 
        public virtual DbSet<Comment> Comments { get; set; } 
        public virtual DbSet<Order> Orders { get; set; } 
        public virtual DbSet<Category> Categories { get; set; } 
        public virtual DbSet<Seller> Sellers { get; set; }

    }
}
