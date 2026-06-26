using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingListItem;
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

    public async Task<bool> DeleteShoppingListItemByShoppingListIdAsync(int shoppingListItemId)
    {
       var shoppingListItem = await GetShoppingListItemByShoppingListItemIdAsync(shoppingListItemId);
       if(shoppingListItem is null)
            return false;
        _db.ShoppingListItems.Remove(shoppingListItem);
        _db.SaveChanges();
        return true;
    }

    public async Task<bool> DeleteShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId)
    {
       var result = await GetShoppingListItemByShoppingListIdAsync(shoppingListItemId);
        if(result is null)
            return false;
        _db.ShoppingListItems.RemoveRange(result);
        _db.SaveChanges();
        return true;

    }

    public async Task<IEnumerable<ShoppingListItem>> GetShoppingListItemByShoppingListIdAsync(int shoppingListId)
    {
       var result = await _db.ShoppingListItems.Where(s => s.ShoppingListId == shoppingListId).ToListAsync();
        return result;
    }
	public async Task<ShoppingListItem?> GetShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId)
	{
		return await _db.ShoppingListItems.Where(s => s.ShoppingListItemId == shoppingListItemId).FirstOrDefaultAsync();
		
	}
}
