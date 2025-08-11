using Microsoft.EntityFrameworkCore;
using MiniCatalogo.Core.Interfaces;
using MiniCatalogo.Infra.Data;
using MiniCatalogo.Infra.Services;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

// 1. Configuração da Web API
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseInMemoryDatabase("ProductDB"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.MapPost("/products", async (IProductService productService, string name, decimal price, string type) => {
    try
    {
        var product = await productService.CreateProductAsync(name, price, type);
        return Results.Created($"/products/{product.Id}", product);
    }
    catch (ArgumentException ex)
    {
        return Results.BadRequest(ex.Message);
    }
});

/*
// 2. Criação da rota ou endpoint monolitico
// SRP (Single Responsibility Principle)
app.MapPost("/products", async (ProductDbContext db, Product product) =>
{
    if (string.IsNullOrEmpty(product.Name) || product.Price <= 0)
    {
        return Results.BadRequest("Invalid product data.");
    }

    // OCP (Open-Closed Principle)
    decimal finalPrice = product.Price;
    if (product.Type == "Eletronico")
    {
        finalPrice *= 0.9m; // 10% discount for electronic products
    }
    else if (product.Type == "Vestuário")
    {
        finalPrice *= 0.8m; // 20% discount for veterinary products
    }

    var finalProduct = new Product
    {
        Name = product.Name,
        Price = finalPrice,
        Type = product.Type
    }; 

    db.Products.Add(finalProduct);
    await db.SaveChangesAsync();

    Console.WriteLine($"Product added: {finalProduct.Name}, Price: {finalProduct.Price}, Type: {finalProduct.Type}");

    return Results.Created($"/products/{product.Id}", product);
});
*/
app.MapGet("/products", async (ProductDbContext db) =>
{
    var products = await db.Products.ToListAsync();
    return Results.Ok(products);
});

app.Run();



// 3. Definições de Entidade e Context
// DIP (Dependency Iversion Principle)
public class Product
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public decimal Price { get; set; }
    public string Type { get; set; } // exe. eletônico, vetuário

}

public class ProductDbContext : DbContext
{
    public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options) { }
    public DbSet<Product> Products { get; set; }
}