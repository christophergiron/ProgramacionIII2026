using Microsoft.Data.Sqlite;

namespace Clase8.Repository;

public class SQLiteProductRepository : IProductRepository
{
    private SqliteConnection _connection;

    public SQLiteProductRepository(string connectionString)
    {
        _connection = new SqliteConnection(connectionString);
    }
    
    public Task Save(ProductDto product)
    {
        throw new NotImplementedException();
    }

    public Task<ProductDto> Get(string id)
    {
        _connection.Open();
        var command = _connection.CreateCommand();
        command.CommandText = "SELECT id, name, price, provider FROM products WHERE id = @id";
        command.Parameters.AddWithValue("@id", id);
        var reader = command.ExecuteReader();
        ProductDto productDto; 
        while (reader.Read())
        {
            productDto = new()
            {
                ID = reader.GetString(0),
                Name = reader.GetString(1),
                Price = reader.GetDecimal(2),
                Provider = reader.GetString(3)
            };
        }
        return productDto;
    }

    public Task<List<ProductDto>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task Delete(string id)
    {
        throw new NotImplementedException();
    }
}