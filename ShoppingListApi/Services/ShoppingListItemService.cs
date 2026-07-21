using ShoppingListApi.Domain.Entities;
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
       var shoppingListItems = new List<ShoppingListItem>();
        foreach (var item in items)
        {
            
            var shoppinglistItem = new ShoppingListItem()
            {
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                ShoppingListId = item.ShoppingListId,
                Unit = item.Unit,
                IsChecked = item.IsChecked
            };
            shoppingListItems.Add(shoppinglistItem);
        }
        return await _repository.CreateShoppingListItemsAsync(shoppingListItems);
    }

    public async Task<bool> UpdateCheckedStatusAsync(string userId, int shoppingListItemId, bool isChecked)
    {
        return await _repository.UpdateCheckedStatusAsync(userId, shoppingListItemId, isChecked);

    }

    public async Task<bool> DeleteShoppingListItemAsync(string userId, int shoppingListItemId)
    {
        return await _repository.DeleteShoppingListItemAsync(userId, shoppingListItemId);
    }
}
