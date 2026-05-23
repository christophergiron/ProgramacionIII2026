using Clase10.Domain;

namespace Clase10.Services;

public interface IProductService
{
    Task<List<Product>> GetAllAsync();
    Task<Product> GetByIdAsync(string id);
    Task Save(Product product);
    Task ChangeName(string id, string newName);
    Task ChangePrice(string id, decimal newPrice);
    Task CreateDiscount(string id, decimal discountAmount);
}