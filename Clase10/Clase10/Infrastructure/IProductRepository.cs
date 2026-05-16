using Clase10.API.Endpoints;

namespace Clase10.Infrastructure;

public interface IProductRepository
{
 public Task<List<ProductDto>> GetAll();
 public Task<ProductDto> Get(string id);
 public Task Save(SaveProductDto productDto);
}