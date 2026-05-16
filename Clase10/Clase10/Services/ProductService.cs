using Clase10.Domain;
using Clase10.Infrastructure;

namespace Clase10.Services;

public class ProductService
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