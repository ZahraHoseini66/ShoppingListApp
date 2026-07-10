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

    public async Task<ShoppingList> CreateShoppingListAsync(string userId, CreateShoppingListRequest request)
    {
        var shoppingList = new ShoppingList
        {
            Title = request.Title,
            StoreId = request.StoreId,
            Status = ShoppingListStatus.Active,
            CreatedAt = DateTime.UtcNow,
            UserId = userId
        };
        return await _repository.CreateShoppingListAsync(shoppingList);
    }

    public Task<ShoppingListDetailsResponse?> GetShoppingListsByShoppingListIdAsync(string userId, int shoppingListId)
    {
        return _repository.GetByShoppingListIdAsync( userId,shoppingListId);
    }

    public async Task<IEnumerable<ShoppingListSummaryResponse>> GetShoppingListsByUserIdAsync(string userId)
    {
        return await _repository.GetByUserIdAsync(userId);
    }

    
}
