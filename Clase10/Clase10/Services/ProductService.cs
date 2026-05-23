using Clase10.Domain;
using Clase10.Infrastructure;

namespace Clase10.Services;

public class ProductService : IProductService
{
    private IProductRepository _repository;
    
    public ProductService(IProductRepository productRepository)
    {
        this._repository = productRepository;
    }

    public async Task<List<Product>> GetAllAsync()
    {
        var productDtos = await _repository.GetAll();
        List<Product> products = new List<Product>();
        
        foreach (var p in productDtos)
        {
            var current = new Product(p.Id, p.Name, p.Description, p.Price, p.Stock);
            products.Add(current);
        }
        return  products;
    }

    public async Task<Product> GetByIdAsync(string id)
    {
        var dto = await _repository.Get(id);
        if (dto == null)
        {
            return null;
        }
        return new Product(dto.Id, dto.Name, dto.Description, dto.Price, dto.Stock);
    }

    public async Task ChangeName(string id, string newName)
    {
        var dto = await _repository.Get(id);
        var record = new SaveProductDto
        {
            Id = id,
            Name = newName,
            Price = dto.Price,
            Description = dto.Description
        };
        await _repository.Save(record);
    }

    public Task ChangePrice(string id, decimal newPrice)
    {
        throw new NotImplementedException();
    }

    public Task CreateDiscount(string id, decimal discountAmount)
    {
        throw new NotImplementedException();
    }

    public Task Save(Product product)
    {
        var dto = new SaveProductDto();
        dto.Id = product.Id;
        dto.Name = product.Name;
        dto.Description = product.Description;
        dto.Price = product.Price;
        
        return _repository.Save(dto);
    }
}