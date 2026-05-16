using Clase9_Ejemplo.Domain.Entities;

namespace Clase9_Ejemplo.Application.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task<IEnumerable<Product>> GetByNameAsync(string name);
}
