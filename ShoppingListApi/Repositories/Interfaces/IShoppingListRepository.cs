using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListRepository
{
	Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId);
	Task<ShoppingList?> GetByShoppingListIdAsync(int shoppingListId);
	Task<IEnumerable<ShoppingList>> SearchAsync(string userId, ShoppingListSearchRequest request);

	Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);
}
