using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingListItem;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListItemService
{
	Task<ShoppingListItem> CreateShoppingListItemAsync(CreateShoppingListItemRequest item);
	Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<CreateShoppingListItemRequest> items);
	Task<IEnumerable<ShoppingListItem>> GetShoppingListItemByShoppingListIdAsync(int shoppingListId);
	Task<bool> DeleteShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId);
	Task<bool> DeleteShoppingListItemByShoppingListIdAsync(int shoppingListId);
}
