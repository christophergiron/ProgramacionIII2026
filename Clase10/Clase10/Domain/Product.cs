namespace Clase10.Domain;


public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
    public string Status  { get; set; }
    
    public Product(string id, string name, string description, decimal price, int stock)
    {
        Id = id;
        Name = name;
        Description = description;
        Price = price;
        Stock = stock;
    }

    public void CreateDiscount(decimal amount)
    {
        Price = Price - amount;
    }

    public void ChangePrice(decimal newPrice)
    {
        Price = newPrice;
    }

    public void AddStock(int amount)
    {
        Stock = Stock + amount;
    }

    public void DiscountStock(int amount)
    {
        Stock -= amount;
    }

    public void Discontinue()
    {
        Status = Enums.ProductStatusDiscontinued;
    }
}