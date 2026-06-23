using System.Collections;
using Microsoft.AspNetCore.Http;
using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListItemRepository
{
	public Task<ShoppingListItem> CreateShippingListItemAsync(ShoppingListItem item);
	public Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<ShoppingListItem> items);
	public Task<ShoppingListItem?> GetShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId);

	public Task<IEnumerable<ShoppingListItem>> GetShoppingListItemByShoppingListIdAsync(int shoppingListId);
	public Task<bool> DeleteShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId);
	public Task<bool> DeleteShoppingListItemByShoppingListIdAsync(int shoppingListItemId);

}
