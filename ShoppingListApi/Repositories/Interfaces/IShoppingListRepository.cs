using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListRepository
{
	Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId);
	Task<ShoppingList> CreateShoppingList(ShoppingList shoppingList);
}
