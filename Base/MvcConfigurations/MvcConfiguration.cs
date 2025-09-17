using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderService.Config;
using OrderService.Configurations;
using OrderService.Context;

namespace OrderService.Base.MvcConfigurations
{
    public static class MvcConfiguration
    {

        public static IServiceCollection UseService(this IServiceCollection services)
        {
            // Add controllers to handle API endpoints
            services.AddControllers(options =>
            {
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status200OK));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status400BadRequest));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status401Unauthorized));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status404NotFound));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status408RequestTimeout));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status502BadGateway));
            });

            // Configure CORS policy to allow all origins, headers, and methods
            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                    policy.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
            });

            // Configure Swagger/OpenAPI for API documentation
            services.AddEndpointsApiExplorer()
                    .AddSwaggerGen()
                    .AddOpenApi();

            // Configure SQL Server database context
            services.AddDbContext<AppDBContext>(options =>
                    options.UseSqlServer(AppSettingsHelper.GetConnectionString()));

            // Configure Dependency Injection for application services
            services.AddDependencyInjection();

            return services;
        }

        public static IApplicationBuilder UseApi(this IApplicationBuilder app)
        {
            // Apply CORS policy
            app.UseCors(c =>
            {
                c.AllowAnyOrigin();
                c.AllowAnyMethod();
                c.AllowAnyOrigin();
                c.WithExposedHeaders("AllowAll");
            });

            app.UseRouting()
               .UseHttpsRedirection()
               .UseAuthorization()
               .UseEndpoints(e => e.MapControllers());

            return app;
        }
    }
}
