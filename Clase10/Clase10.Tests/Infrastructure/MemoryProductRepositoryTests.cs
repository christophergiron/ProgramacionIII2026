using Clase10.Infrastructure;

namespace Clase10.Tests.Infrastructure;

public class MemoryProductRepositoryTests
{
    
    private readonly MemoryProductRepository _repository;
    public MemoryProductRepositoryTests()
    {
        _repository = new MemoryProductRepository();
    }

    [Test]
    public async Task GetAll()
    {
        //Arrange
        //Act 
        var products = await _repository.GetAll();
        //Assert
        Assert.That(products, Has.Count.GreaterThan(0));
    }
}