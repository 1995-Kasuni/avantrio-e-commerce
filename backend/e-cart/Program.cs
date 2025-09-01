using e_cart.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

var product = new List<Products>
{
    new Products { Id = 1, Name = "bag", Price = 10.00M },
    new Products { Id = 2, Name = "bottle", Price = 20.00M },
    new Products { Id = 3, Name = "hat", Price = 30.00M },
};

var cart = new List<CartItems>();

app.MapGet("api/products", () => product);

app.MapPost("/api/cart", ([FromBody] CartItems item) =>
{
    var existing = cart.FirstOrDefault(c => c.ProductId == item.ProductId);
    if (existing != null)
    {
        existing.ProductQuantity += existing.ProductQuantity;
    }
    else
    {
        cart.Add(item);
    }
});

app.MapGet("/api/cart", () =>
{
    return Results.Ok(cart);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

app.UseCors(policy => policy
.AllowAnyOrigin()
.AllowAnyMethod()
.AllowAnyHeader()
);
