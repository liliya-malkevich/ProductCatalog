using products_catalog.Server.Database;
using Microsoft.EntityFrameworkCore;
using products_catalog.Server.Repositories.Impl;
using products_catalog.Server.Repositories;
using products_catalog.Server.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationContext>(o => o.UseSqlServer(
    builder.Configuration.GetConnectionString("ProductConnection"))
);

builder.Services.AddTransient<IBaseRepo<CategoryItem>, CategoryRepo>();
builder.Services.AddTransient<IBaseRepo<Product>, ProductRepo>();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(o => o
    .AllowCredentials()
    .AllowAnyHeader()
    .AllowAnyMethod()
    .SetIsOriginAllowed(x => true)
);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
