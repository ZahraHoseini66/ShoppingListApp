using Microsoft.EntityFrameworkCore;
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

    public async Task<bool> DeleteShoppingListItemAsync(string userId, int shoppingListItemId)
    {
        var shoppingListItem = await _db.ShoppingListItems.Where(sh => sh.ShoppingList.UserId == userId && sh.ShoppingListItemId == shoppingListItemId).FirstOrDefaultAsync();
        if ( shoppingListItem is null)
            return false;
         _db.ShoppingListItems.Remove(shoppingListItem);
        await _db.SaveChangesAsync();
        return true ;

    }

    public async Task<bool> UpdateCheckedStatusAsync(string userId ,int shoppingListItemId, bool isChecked)
    {

         ShoppingListItem? shoppingListItem = await _db.ShoppingListItems
    .Where(sh => sh.ShoppingListItemId == shoppingListItemId && sh.ShoppingList.UserId == userId)
    .FirstOrDefaultAsync();
        if (shoppingListItem is null)
            return false;
        shoppingListItem.IsChecked = isChecked;     
        await _db.SaveChangesAsync();
        return true;
    }

}
