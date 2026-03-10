using Microsoft.AspNetCore.Http;
using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IShoppingListItemRepository
{
	public Task<IResult> CreateShippingListItem
	public Task<IResult> CreateShoppingListItems(int shoppingListId,List<ShoppingListItem> items);
}
