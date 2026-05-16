using Clase9_Ejemplo.Application.DTOs;
using Clase9_Ejemplo.Application.Interfaces;
using Clase9_Ejemplo.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Clase9_Ejemplo.Api.Endpoints;

public static class ProductEndpoints
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/products").WithTags("Productos");

        // GET all products - público
        group.MapGet("/", async (IProductRepository repo) =>
        {
            var products = await repo.GetAllAsync();
            return Results.Ok(products.Select(MapToDto));
        })
        .WithName("GetAllProducts")
        .WithOpenApi();

        // GET product by id - público
        group.MapGet("/{id:int}", async (int id, IProductRepository repo) =>
        {
            var product = await repo.GetByIdAsync(id);
            return product is null
                ? Results.NotFound()
                : Results.Ok(MapToDto(product));
        })
        .WithName("GetProductById")
        .WithOpenApi();

        // POST create product - requiere autenticación
        group.MapPost("/", async (CreateProductDto dto, IProductRepository repo) =>
        {
            var product = new Product
            {
                Name = dto.Name,
                Description = dto.Description,
                Price = dto.Price,
                Stock = dto.Stock
            };
            var created = await repo.AddAsync(product);
            return Results.Created($"/api/products/{created.Id}", MapToDto(created));
        })
        .RequireAuthorization()
        .WithName("CreateProduct")
        .WithOpenApi();

        // PUT update product - requiere autenticación
        group.MapPut("/{id:int}", async (int id, UpdateProductDto dto, IProductRepository repo) =>
        {
            var product = await repo.GetByIdAsync(id);
            if (product is null)
                return Results.NotFound();

            product.Name = dto.Name;
            product.Description = dto.Description;
            product.Price = dto.Price;
            product.Stock = dto.Stock;

            await repo.UpdateAsync(product);
            return Results.Ok(MapToDto(product));
        })
        .RequireAuthorization()
        .WithName("UpdateProduct")
        .WithOpenApi();

        // DELETE product - requiere rol Admin
        group.MapDelete("/{id:int}", async (int id, IProductRepository repo) =>
        {
            await repo.DeleteAsync(id);
            return Results.NoContent();
        })
        .RequireAuthorization("AdminOnly")
        .WithName("DeleteProduct")
        .WithOpenApi();
    }

    private static ProductDto MapToDto(Product product) => new()
    {
        Id = product.Id,
        Name = product.Name,
        Description = product.Description,
        Price = product.Price,
        Stock = product.Stock
    };
}
