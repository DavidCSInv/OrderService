using Microsoft.EntityFrameworkCore;
using OrderService.Base;
using OrderService.Models;

namespace OrderService.Context;
public class AppDBContext(DbContextOptions<AppDBContext> options) : DbContext(options)
{
    public DbSet<Customer> Customers { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ImageModel> Images { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ConfigureBaseKeys(typeof(BaseModel));
        modelBuilder.Entity<Customer>().OwnsOne(c => c.UserProfilePicture);

        base.OnModelCreating(modelBuilder);
    }

}

/// <summary>
/// Extension method for <see cref="ModelBuilder"/> that automatically configures
/// a primary key named "Id" for all entities deriving from the specified base type.
/// 
/// This is useful to avoid explicitly defining a primary key in every migration.
/// It skips abstract classes and owned entity types.
/// </summary>
/// <param name="modelBuilder">The <see cref="ModelBuilder"/> instance to configure.</param>
/// <param name="baseType">The base type that target entities inherit from.</param
public static class ModelBuilderExtensions
{
    public static void ConfigureBaseKeys(this ModelBuilder modelBuilder, Type baseType)
    {
        foreach (var entityType in modelBuilder.Model.GetEntityTypes())
        {
            var clrType = entityType.ClrType;
            if (clrType.IsAbstract) continue;
            if (entityType.IsOwned()) continue;

            if (baseType.IsAssignableFrom(clrType))
            {
                var pkName = $"PK_{clrType.Name}";
                modelBuilder.Entity(clrType)
                            .HasKey("Id")
                            .HasName(pkName);
            }
        }
    }
}