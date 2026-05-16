using Clase9_Ejemplo.Application.Interfaces;
using Clase9_Ejemplo.Domain.Entities;
using Clase9_Ejemplo.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Clase9_Ejemplo.Infrastructure.Repositories;

public class ProductRepository : Repository<Product>, IProductRepository
{
    public ProductRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Product>> GetByNameAsync(string name)
    {
        return await _dbSet.Where(p => p.Name.Contains(name)).ToListAsync();
    }
}
