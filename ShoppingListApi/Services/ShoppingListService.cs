using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Services;

public class ShoppingListService: IShoppingListService
{
	private readonly IShoppingListRepository _repository;
    public ShoppingListService(IShoppingListRepository repository)
    {
        _repository = repository;
    }

    public async Task<ShoppingList> CreateShoppingListAsync(string UserId, CreateShoppingListRequest request)
    {
        var shoppingList = new ShoppingList
        {
            Title = request.Title,
            StoreId = request.StoreId,
            Status = ShoppingListStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UserId = UserId
        };
        return await _repository.CreateShoppingListAsync(shoppingList);
    }

    public async Task<ShoppingList?> GetByShoppingListIdAsync(int shoppingListId)
    {
        return await _repository.GetByShoppingListIdAsync(shoppingListId);
    }

    public async Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId)
    {
      return await  _repository.GetByUserIdAsync(userId);
    }

    public async Task<IEnumerable<ShoppingList>> SearchAsync(string userId, ShoppingListSearchRequest request)
    {
        return await _repository.SearchAsync(userId, request);
    }

  
}
