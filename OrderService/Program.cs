using Microsoft.EntityFrameworkCore;
using OrderService.Config;
using OrderService.Configurations;
using OrderService.Context;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//Implementing The Database Conection

builder.Services.AddDbContext<AppDBContext>(options =>
    options.UseSqlServer(AppSettingsHelper.GetConnectionString()));

// This method gets called by the runtime. Use this method to add services to the container.

builder.Services
    .AddDependencyInjection()
    .AddEndpointsApiExplorer()
    .AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseRouting();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
