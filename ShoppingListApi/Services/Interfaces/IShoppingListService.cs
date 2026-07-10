using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListService
{
	Task<ShoppingList> CreateShoppingListAsync(string userId, CreateShoppingListRequest request);
	Task<IEnumerable<ShoppingListSummaryResponse>> GetShoppingListsByUserIdAsync(string userId);
    Task<ShoppingListDetailsResponse?> GetShoppingListsByShoppingListIdAsync(string userId,int shoppingListId);

}
