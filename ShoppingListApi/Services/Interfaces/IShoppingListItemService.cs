using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingListItem;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListItemService
{
	Task<ShoppingListItem> CreateShoppingListItemAsync(CreateShoppingListItemRequest item);
	Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<ShoppingListItem> items);
    Task<bool> UpdateCheckedStatusAsync(int shoppingListItemId, bool isChecked);


}
