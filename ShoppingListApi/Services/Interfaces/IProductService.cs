using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Product;

namespace ShoppingListApi.Services.Interfaces;

public interface IProductService
{
	Task<Product> CreateProductAsync(CreateProductRequest request);
    Task<Product?> GetProductByIdAsync(int productId);
    Task<IEnumerable<Product>> GetProductsByTitleAsync(string title);
}
