using MicroCommerce.Application;
using MicroCommerce.Infrastructure;
using MicroCommerce.WebAPI.Middlewares;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// =====================================================
// Service Registration (Dependency Injection)
// =====================================================

// Register Application layer services (MediatR, AutoMapper, FluentValidation)
builder.Services.AddApplicationServices();

// Register Infrastructure layer services (EF Core, Repositories, UoW)
builder.Services.AddInfrastructureServices(builder.Configuration);

// Controllers
builder.Services.AddControllers();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "MicroCommerce API",
        Version = "v1",
        Description = "A modern Micro-Commerce E-Commerce Backend API built with .NET 8 and Clean Architecture.",
        Contact = new OpenApiContact
        {
            Name = "MicroCommerce Team"
        }
    });

    // Include XML comments for better Swagger documentation
    var xmlFile = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    if (File.Exists(xmlPath))
    {
        options.IncludeXmlComments(xmlPath);
    }
});

// CORS (ready for future frontend integration)
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

var app = builder.Build();

// =====================================================
// Middleware Pipeline
// =====================================================

// Global exception handling (must be first in pipeline)
app.UseMiddleware<ExceptionHandlingMiddleware>();

// Swagger (available in all environments for development convenience)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "MicroCommerce API v1");
        options.RoutePrefix = string.Empty; // Swagger at root URL
    });
}

app.UseHttpsRedirection();

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();
