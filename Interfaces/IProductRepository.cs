using GraphNet.Entities.Models;

namespace GraphNet.Interfaces;

public interface IProductRepository
{
    IEnumerable<Product> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product?> UpdateProduct(int id, Product product);
    Task<Product?> DeleteProduct(int id);
}