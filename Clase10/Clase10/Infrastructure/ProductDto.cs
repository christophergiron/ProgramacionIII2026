namespace Clase10.Infrastructure;

public record ProductDto
{
     public string Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public decimal Price { get; set; }
     public int Stock { get; set; }
}

public record SaveProductDto
{
     public string Id { get; set; }
     public string Name { get; set; }
     public string Description { get; set; }
     public decimal Price { get; set; }
}
