using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListItemRepository
{
	public Task<ShoppingListItem> CreateShippingListItemAsync(ShoppingListItem item);
	public Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<ShoppingListItem> items);
	public Task<bool> UpdateCheckedStatusAsync(string userId, int shoppingListItemId, bool isChecked);
    public Task<bool> DeleteShoppingListItemAsync(string userId, int shoppingListItemId);
}
