namespace Clase8.Repository;

public interface IProductRepository
{
    public Task Save(ProductDto product);
    public Task<ProductDto> Get(string id);
    public Task<List<ProductDto>> GetAll();
    public Task Delete(string id);
}