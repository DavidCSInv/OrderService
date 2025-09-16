using Microsoft.AspNetCore.Mvc;

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
                options.Filters.Add(new ProducesResponseTypeAttribute(StatusCodes.Status500InternalServerError));
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
               .UseAuthorization();

            return app;
        }
    }
}
