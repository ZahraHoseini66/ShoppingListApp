using ShoppingListApi.Domain.Entities;
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
    public async Task<ShoppingListItem> SaveShoppingListItemAsync(ShoppingListItem item)
    {
        return await _repository.CreateShippingListItemAsync(item);
    }

    public async Task<IEnumerable<ShoppingListItem>> SaveShoppingListItemsAsync(IEnumerable<ShoppingListItem> items)
    {
        return await _repository.CreateShoppingListItemsAsync(items);
    }


}
