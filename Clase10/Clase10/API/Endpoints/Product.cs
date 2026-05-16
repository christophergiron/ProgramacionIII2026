using Clase10.Infrastructure;
using Clase10.Services;

namespace Clase10.API.Endpoints;

public static class Product
{
    public static void MapProductEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/products").WithTags("Products");
        
        group.MapGet("/", (IProductRepository productRepository) =>
        {
            ProductService service = new ProductService(productRepository);
            return service.GetAllAsync();
        }).WithName("GetAll");
        
        group.MapGet("/{id}", async (string id, IProductRepository productRepository) =>
        {
            ProductService service = new ProductService(productRepository);
            var product = await service.GetByIdAsync(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }).WithName("Get");

        group.MapPost("/", async (SaveProductDto product, IProductRepository productRepository) =>
        {
            ProductService service = new ProductService(productRepository);
            Domain.Product saveProduct = new Domain.Product(
                product.Id, product.Name, product.Description, product.Price, 0);
            await service.Save(saveProduct);
            
        }).WithName("Create");
    }
}