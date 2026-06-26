using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualBasic;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Repositories;

public class ShoppingListItemRepository : IShoppingListItemRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingListItemRepository(ApplicationDbContext db)
    {
        _db = db; 
    }

    public async Task<ShoppingListItem> CreateShippingListItemAsync(ShoppingListItem item)
    {
        await _db.ShoppingListItems.AddAsync(item);
        await _db.SaveChangesAsync();
        return item;
    }


    public async Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<ShoppingListItem> items)
    {
       
            await _db.ShoppingListItems.AddRangeAsync(items);
            await _db.SaveChangesAsync();

        return items;
       
    }

    
}
