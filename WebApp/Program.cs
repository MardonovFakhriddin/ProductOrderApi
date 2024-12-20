using Domain.Models;
using Infrastructure.Data;
using Infrastructure.Services;
using Infrastructure.Interfaces;
using WebApp.Controllers;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IContext,DapperContext>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "JobBoardManagement"));
}

app.MapControllers();
app.Run();