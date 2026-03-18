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

    public async Task<IEnumerable<ShoppingListItem>> CreateShoppingListItemsAsync(IEnumerable<ShoppingListItem> items)
    {
        return await _repository.CreateShoppingListItemsAsync(items);
    }


}
