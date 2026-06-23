using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Repositories;

public class ProductRepository:IProductRepository
{
	private readonly ApplicationDbContext _db;
	public ProductRepository(ApplicationDbContext db)
	{
		_db = db;
	}

    public async Task<Product> CreateProductAsync(Product product)
    {

        await _db.Products.AddAsync(product);
        await _db.SaveChangesAsync();
        return product;
            }

    public async Task<Product?> GetProductByIdAsync(int productId)
    {
        return await _db.Products.Where(p => p.ProductId == productId).FirstOrDefaultAsync();

    }

    public async Task<IEnumerable<Product>> GetProductsByTitleAsync(string title)
    {
     return await _db.Products.Where(p => p.Title.Contains(title.Trim('"'))).ToListAsync();
    }
}
