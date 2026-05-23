using Dapper;
using Npgsql;

namespace Clase10.Infrastructure;

public class PostgresProductRepository : IProductRepository
{
    private readonly string _connectionString;

    public PostgresProductRepository(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("Postgres")!;
    }

    public async Task<List<ProductDto>> GetAll()
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = @"
            SELECT
                id,
                name,
                description,
                price
            FROM products
            ORDER BY name;
        ";

        var result = await connection.QueryAsync<ProductDto>(sql);

        return result.ToList();
    }

    public async Task<ProductDto> Get(string id)
    {
        using var connection = new NpgsqlConnection(_connectionString);
        var sql = @"
            SELECT
                id,
                name,
                description,
                price
            FROM products
            WHERE id = @Id; 
        ";

        return await connection.QueryFirstOrDefaultAsync<ProductDto>(sql, new
        {
            Id = id
        });
    }

    public async Task Save(SaveProductDto productDto)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var exists = await connection.ExecuteScalarAsync<int>(@"
            SELECT COUNT(*)
            FROM products
            WHERE id = @Id;
        ", new
        {
            productDto.Id
        });

        if (exists == 0)
        {
            var insertSql = @"
                INSERT INTO products
                (
                    id,
                    name,
                    description,
                    price
                )
                VALUES
                (
                    @Id,
                    @Name,
                    @Description,
                    @Price
                );
            ";

            await connection.ExecuteAsync(insertSql, productDto);

            return;
        }

        var updateSql = @"
            UPDATE products
            SET
                name = @Name,
                description = @Description,
                price = @Price
            WHERE id = @Id;
        ";

        await connection.ExecuteAsync(updateSql, productDto);
    }
}