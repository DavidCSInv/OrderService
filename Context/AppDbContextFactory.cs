using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using OrderService.Config;
using OrderService.Context;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDBContext>
{
    /// <summary>
    /// Creates and configures a new instance of <see cref="AppDBContext"/> using the application's connection string.
    /// </summary>
    /// <remarks>The connection string is retrieved using <see cref="AppSettingsHelper.GetConnectionString"/>.
    /// Ensure that the connection string is properly configured in the application's settings before calling this
    /// method.</remarks>
    /// <param name="args">An array of command-line arguments. This parameter is not used in the current implementation.</param>
    /// <returns>A new instance of <see cref="AppDBContext"/> configured with the application's connection string.</returns>
    public AppDBContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDBContext>();
        optionsBuilder.UseSqlServer(AppSettingsHelper.GetConnectionString());
        return new AppDBContext(optionsBuilder.Options);
    }
}
