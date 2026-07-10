using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListRepository
{
	Task<IEnumerable<ShoppingListSummaryResponse>> GetByUserIdAsync(string userId);
    Task<ShoppingListDetailsResponse?> GetByShoppingListIdAsync(string userId, int shoppingListId);

    Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList);

}
