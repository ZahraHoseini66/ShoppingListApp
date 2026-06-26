using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListService
{
	Task<ShoppingList> CreateShoppingListAsync(string userId, CreateShoppingListRequest request);
	Task<IEnumerable<ShoppingList>> GetShoppingListsByUserIdAsync(string userId);
}
