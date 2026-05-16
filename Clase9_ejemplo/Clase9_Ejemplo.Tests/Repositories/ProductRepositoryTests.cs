using Clase9_Ejemplo.Application.Interfaces;
using Clase9_Ejemplo.Domain.Entities;
using Clase9_Ejemplo.Infrastructure.Data;
using Clase9_Ejemplo.Infrastructure.Repositories;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;
using Xunit;

namespace Clase9_Ejemplo.Tests.Repositories;

public class ProductRepositoryTests : IDisposable
{
    private readonly AppDbContext _context;
    private readonly ProductRepository _repository;

    public ProductRepositoryTests()
    {
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;
        _context = new AppDbContext(options);
        _repository = new ProductRepository(_context);
    }

    public void Dispose()
    {
        _context.Dispose();
    }

    [Fact]
    public async Task AddAsync_ShouldAddProduct()
    {
        // Arrange
        var product = new Product
        {
            Name = "Test Product",
            Description = "Test Description",
            Price = 99.99m,
            Stock = 10
        };

        // Act
        var result = await _repository.AddAsync(product);

        // Assert
        result.Should().NotBeNull();
        result.Id.Should().BeGreaterThan(0);
        result.Name.Should().Be("Test Product");
    }

    [Fact]
    public async Task GetByIdAsync_WithExistingId_ShouldReturnProduct()
    {
        // Arrange
        var product = new Product
        {
            Name = "Test Product",
            Description = "Test Description",
            Price = 99.99m,
            Stock = 10
        };
        await _repository.AddAsync(product);

        // Act
        var result = await _repository.GetByIdAsync(product.Id);

        // Assert
        result.Should().NotBeNull();
        result!.Name.Should().Be("Test Product");
    }

    [Fact]
    public async Task GetByIdAsync_WithNonExistingId_ShouldReturnNull()
    {
        // Act
        var result = await _repository.GetByIdAsync(999);

        // Assert
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetAllAsync_ShouldReturnAllProducts()
    {
        // Arrange
        await _repository.AddAsync(new Product { Name = "Product 1", Price = 10 });
        await _repository.AddAsync(new Product { Name = "Product 2", Price = 20 });
        await _repository.AddAsync(new Product { Name = "Product 3", Price = 30 });

        // Act
        var result = await _repository.GetAllAsync();

        // Assert
        result.Should().HaveCount(3);
    }

    [Fact]
    public async Task UpdateAsync_ShouldUpdateProduct()
    {
        // Arrange
        var product = new Product
        {
            Name = "Original Name",
            Price = 50m
        };
        await _repository.AddAsync(product);

        // Act
        product.Name = "Updated Name";
        product.Price = 75m;
        await _repository.UpdateAsync(product);

        // Assert
        var updated = await _repository.GetByIdAsync(product.Id);
        updated!.Name.Should().Be("Updated Name");
        updated.Price.Should().Be(75m);
    }

    [Fact]
    public async Task DeleteAsync_ShouldRemoveProduct()
    {
        // Arrange
        var product = new Product
        {
            Name = "To Delete",
            Price = 10
        };
        await _repository.AddAsync(product);
        var productId = product.Id;

        // Act
        await _repository.DeleteAsync(productId);

        // Assert
        var result = await _repository.GetByIdAsync(productId);
        result.Should().BeNull();
    }

    [Fact]
    public async Task GetByNameAsync_ShouldReturnMatchingProducts()
    {
        // Arrange
        await _repository.AddAsync(new Product { Name = "Laptop Dell", Price = 500 });
        await _repository.AddAsync(new Product { Name = "Mouse Logitech", Price = 50 });
        await _repository.AddAsync(new Product { Name = "Keyboard Dell", Price = 100 });

        // Act
        var result = await _repository.GetByNameAsync("Dell");

        // Assert
        result.Should().HaveCount(2);
    }
}
