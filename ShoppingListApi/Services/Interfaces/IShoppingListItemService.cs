using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListItemService
{
	Task<ShoppingListItem> SaveShoppingListItemAsync(ShoppingListItem item);
	Task<IEnumerable<ShoppingListItem>> SaveShoppingListItemsAsync(IEnumerable<ShoppingListItem> items);
}
