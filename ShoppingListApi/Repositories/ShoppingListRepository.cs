using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingListRepository(ApplicationDbContext db)
    {
        _db = db;
        
    }

    public async Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList)
    {
        await _db.ShoppingLists.AddAsync(shoppingList);
        await _db.SaveChangesAsync();
        return shoppingList;
    }

    public async Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId)
    {
        return await _db.ShoppingLists
            .Where(sh => sh.UserId == userId).ToListAsync();
    }

 
}
