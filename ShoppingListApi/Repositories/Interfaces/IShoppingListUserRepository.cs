using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListUserRepository
{
	public Task<ShoppingListUser> CreateShoppingListUserAsync(ShoppingListUser item);

}
