using OrderService.Repositories.Implementations;
using OrderService.Repositories.Interfaces;

namespace OrderService.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            //Repositories
            services.AddScoped<ICustomersRepository, CustomersRepository>();
            services.AddScoped<ICategoryrRepository, CategoryRepository>();
            //Controllers and Validations
            services.AddScoped<Controllers.Customer.Validation>();
            return services;

        }
    }
}
