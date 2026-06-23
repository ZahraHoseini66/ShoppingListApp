using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListService
{
	Task<ShoppingList> CreateShoppingListAsync(string UserId, CreateShoppingListRequest request);
	Task<IEnumerable<ShoppingList>> SearchAsync(string userId, ShoppingListSearchRequest request);
	Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId);
	Task<ShoppingList?> GetByShoppingListIdAsync(int shoppingListId);
}
