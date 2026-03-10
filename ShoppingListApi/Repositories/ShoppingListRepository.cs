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
    public async Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId)
    {
        return await _db.ShoppingLists
            .Where(sh => sh.UserID == userId).ToListAsync();
    }

    Task<ShoppingList> IShoppingListRepository.AddShoppingList(ShoppingList shoppingList)
    {
        _db.ShoppingLists.Add(shoppingList);
        _db.SaveChanges();
    }
}
