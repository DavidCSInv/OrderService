using OrderService.Base.MvcConfigurations;

var builder = WebApplication.CreateBuilder(args);

//  Services Configuration 
builder.Services.UseService();

var app = builder.Build();

// Api Configuration
app.UseApi();

//  Middleware Pipeline

// Enable Swagger UI in development environment
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi(); // Maps OpenAPI endpoints if you have a custom setup
}

app.Run();
