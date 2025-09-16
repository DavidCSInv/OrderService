using OrderService.Repositories.Implementations;
using OrderService.Repositories.Interfaces;

namespace OrderService.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICategoryrRepository, CategoryRepository>();

            return services;

        }
    }
}
