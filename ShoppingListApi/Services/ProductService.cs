using Microsoft.AspNetCore.Http.HttpResults;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Product;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _repository;
    public ProductService(IProductRepository repository)
    {
        _repository = repository;   
    }


    public async Task<Product> CreateProductAsync(CreateProductRequest request)
    {
        var product = new Product()
        {
            CategoryId = request.CategoryId,
            Title = request.Title
        };
       return await _repository.CreateProductAsync(product); 
    }

    public async Task<Product> GetProductByIdAsync(int productId)
    {
        return await _repository.GetProductByIdAsync(productId);
    }

    public async Task<IEnumerable<Product>> GetProductsByTitleAsync(string title)
    {
       return await _repository.GetProductsByTitleAsync(title);
    }
}
