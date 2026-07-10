using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.DTOs.ShoppingListItem;
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

    public async Task<ShoppingListDetailsResponse?> GetByShoppingListIdAsync(string userId,int shoppingListId)
    {
        var shoppingList = await _db.ShoppingLists.Where(
            shl => shl.ShoppingListId == shoppingListId &&
            shl.UserId == userId).Include( shoppingList => shoppingList.Items ).FirstOrDefaultAsync();
        if(shoppingList == null)
            return null;
        return new ShoppingListDetailsResponse
        {
            ShoppingListId = shoppingList.ShoppingListId,
            Title = shoppingList.Title,
            StoreId = shoppingList.StoreId,
            Items = shoppingList.Items.Select(item => new ShoppingListItemResponse
            {
                ShoppingListItemId = item.ShoppingListItemId,
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Unit = item.Unit,
                IsChecked = item.IsChecked
            }).ToList()
        };
    }

    public async Task<IEnumerable<ShoppingListSummaryResponse>> GetByUserIdAsync(string userId)
    {
        return await _db.ShoppingLists
            .Where(sh => sh.UserId == userId)
            .Select(sh => new ShoppingListSummaryResponse
            {
                ShoppingListId = sh.ShoppingListId,
                Title = sh.Title,
                StoreId = sh.StoreId,
                Status = sh.Status,
                CreatedAt = sh.CreatedAt
            })
            .ToListAsync();
    }

 
}
