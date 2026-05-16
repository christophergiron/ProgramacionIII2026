namespace Clase8.Repository;

//Mapear a la base de datos DTO=Data Transfer Object
public class ProductDto
{
    public string ID { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string Provider { get; set; }
}