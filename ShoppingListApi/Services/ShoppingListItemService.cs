using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Services;

public class ShoppingListItemService : IShoppingListItemService
{
    private readonly IShoppingListItemRepository _repository;
    public ShoppingListItemService(IShoppingListItemRepository repository)
    {
        _repository = repository;
        
    }
    public async Task<ShoppingListItem> CreateShoppingListItemAsync(CreateShoppingListItemRequest request)
    {
        var shoppinglistItem = new ShoppingListItem()
        {
             ProductId = request.ProductId,
             Quantity = request.Quantity,
             ShoppingListId = request.ShoppingListId,
             Unit = request.Unit,
             IsChecked = request.IsChecked
        };
        return await _repository.CreateShippingListItemAsync(shoppinglistItem);
    }

    public async Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<CreateShoppingListItemRequest> items)
    {
		List<ShoppingListItem> shoppingListItems = new();
		foreach (var item in items)
		{
			shoppingListItems.Add(new()
			{
				ProductId = item.ProductId,
				Unit = item.Unit,
				Quantity = item.Quantity,
				IsChecked = item.IsChecked
			});

		}
		return await _repository.CreateShoppingListItemsAsync(shoppingListItems);
    }

    public async Task<bool> DeleteShoppingListItemByShoppingListIdAsync(int shoppingListId)
    {
       return await _repository.DeleteShoppingListItemByShoppingListIdAsync(shoppingListId);
    }

    public async Task<bool> DeleteShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId)
    {
		return await _repository.DeleteShoppingListItemByShoppingListItemIdAsync(shoppingListItemId);

	}

	public async Task<IEnumerable<ShoppingListItem>> GetShoppingListItemByShoppingListIdAsync(int shoppingListId)
    {
       return await _repository.GetShoppingListItemByShoppingListIdAsync(shoppingListId);
    }
}
