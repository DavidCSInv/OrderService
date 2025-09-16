using Microsoft.EntityFrameworkCore;
using OrderService.Base.MvcConfigurations;
using OrderService.Config;
using OrderService.Configurations;
using OrderService.Context;

var builder = WebApplication.CreateBuilder(args);

//  Services Configuration 
builder.Services.UseService();

// Configure SQL Server database context
builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(AppSettingsHelper.GetConnectionString()));

// Configure Dependency Injection for application services
builder.Services.AddDependencyInjection();

// Configure CORS policy to allow all origins, headers, and methods
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseApi();

//  Middleware Pipeline

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi(); // Maps OpenAPI endpoints if you have a custom setup
}

app.MapControllers();

app.Run();
