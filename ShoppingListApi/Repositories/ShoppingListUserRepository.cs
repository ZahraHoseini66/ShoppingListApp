using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Repositories;

public class ShoppingListUserRepository : IShoppingListUserRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingListUserRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<ShoppingListUser> CreateShoppingListUserAsync(ShoppingListUser item)
    {
        await _db.ShoppingListUsers.AddAsync(item);
        await _db.SaveChangesAsync();
        return item;
    }
}
