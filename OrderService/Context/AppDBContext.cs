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