namespace Clase10.Infrastructure;

public class MemoryProductRepository : IProductRepository
{
    public List<ProductDto> database;

    public MemoryProductRepository()
    {
        database = new List<ProductDto>()
        {
            new ProductDto
            {
                Id ="1",
                Name = "Laptop",
                Price = 5000,
                Description = "Computadora portatil"
            },
            new ProductDto
            {
                Id ="2",
                Name = "Mouse",
                Price = 200,
                Description = "Mouse computadora portatil"
            }
        };
    }
    
    public Task<List<ProductDto>> GetAll()
    {
        return Task.FromResult(database);
    }

    public Task<ProductDto> Get(string id)
    {
       return Task.FromResult(database.Find(x => x.Id == id));
    }

    public Task Save(SaveProductDto productDto)
    {
        var element = database.Find(s => s.Id == productDto.Id);
        if (element == null)
        {
            database.Add(new ProductDto
            {
                Id = productDto.Id, Description =  productDto.Description, Name = productDto.Name,
                Price = productDto.Price,
            });
            return Task.CompletedTask;
        }

        element.Description = productDto.Description;
        element.Name = productDto.Name;
        element.Price = productDto.Price;

        return Task.CompletedTask;
    }
}