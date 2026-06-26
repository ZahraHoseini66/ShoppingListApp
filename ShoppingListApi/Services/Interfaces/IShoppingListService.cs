using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;

namespace ShoppingListApi.Services.Interfaces;

public interface IShoppingListService
{
	Task<ShoppingList> CreateShoppingListAsync(string UserId, CreateShoppingListRequest request);

}
