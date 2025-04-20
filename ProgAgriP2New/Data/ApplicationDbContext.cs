using ProgAgriP2New.Models;
using Microsoft.EntityFrameworkCore;

namespace ProgAgriP2New.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Farmer entity
            modelBuilder.Entity<Farmer>().ToTable("Farmers");
            modelBuilder.Entity<Farmer>().HasKey(f => f.FarmerId);

            // Configure Employee entity
            modelBuilder.Entity<Employee>().ToTable("Employees");
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);

            // Configure Product entity
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);

            // Configure relationship between Farmer and Product
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Farmer)
                .WithMany(f => f.Products)
                .HasForeignKey(p => p.FarmerId)
                .OnDelete(DeleteBehavior.Cascade); // This ensures products are deleted when a farmer is deleted
        }
    }
}