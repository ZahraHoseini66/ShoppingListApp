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
    public async Task<IResult> CreateShoppingListItems(int shoppingListId, List<ShoppingListItem> items)
    {
        foreach (var item in items) {
			await _db.ShoppingListItems.AddAsync(item);
		}
        return Ok();
        
       
        
    }
}
