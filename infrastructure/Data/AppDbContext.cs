using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<ProductGroup> ProductGroups { get; set; }
    public DbSet<ProductCategory> ProductCategories { get; set; }
    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductGroup>()
            .HasMany(pg => pg.ProductCategories)
            .WithOne(pc => pc.ProductGroup)
            .HasForeignKey(pc => pc.GroupId);

        modelBuilder.Entity<ProductCategory>()
            .HasMany(pc => pc.Products)
            .WithOne(p => p.ProductCategory)
            .HasForeignKey(p => p.CategoryId);
    }
}
