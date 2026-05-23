using System.Net;
using Clase10.Infrastructure;
using Clase10.Services;
using Microsoft.AspNetCore.Http.Headers;

namespace Clase10.API.Endpoints;

public static class ProductHandler
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/products").WithTags("Products");
        
        group.MapGet("/", (IProductService service) =>
        {
            return service.GetAllAsync();
        }).WithName("GetAll");
        
        group.MapGet("/{id}", async (string id, IProductService service) =>
        {
            var product = await service.GetByIdAsync(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }).WithName("Get");

        group.MapPost("/", async (SaveProductDto product, IProductService service) =>
        {
            Domain.Product saveProduct = new Domain.Product(
                product.Id, product.Name, product.Description, product.Price, 0);
            await service.Save(saveProduct);
            
        }).WithName("Create");
        
        group.MapPut("/change_name", async (SaveProductDto product, IProductService service) =>
        {
            await service.ChangeName(product.Id, product.Name);
            
        }).WithName("ChangeName");
    }
}