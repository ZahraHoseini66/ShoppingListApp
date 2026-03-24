using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IProductRepository
{
  public Task<Product> CreateProductAsync(Product product);
  public Task<Product?> GetProductByIdAsync(int productId);
  public Task<IEnumerable<Product>> GetProductsByTitleAsync(string title);
}
