using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.Services;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingListItemController : ControllerBase
{
    private readonly IShoppingListItemService _shoppingListItemService;
    public ShoppingListItemController(IShoppingListItemService shoppingListItemService)
    {
        _shoppingListItemService = shoppingListItemService;
    }

    [HttpPost("CreateShoppingListItem")]
    public async Task<IActionResult> CreateShoppingListItemAsync([FromBody] CreateShoppingListItemRequest request)
    {
        var result = await _shoppingListItemService.CreateShoppingListItemAsync(request);
        return Ok(result);
    }
	[HttpPost("CreateShoppingListItems")]
	public async Task<IActionResult> CreateShoppingListItemsAsync([FromBody]IEnumerable<CreateShoppingListItemRequest> request)
	{
		var result = await _shoppingListItemService.CreateShoppingListItemsAsync(request);
		return Ok(result);
	}

	[HttpGet("GetShoppingListItemBuyShoppingListId")]
    public async Task<IActionResult> GetShoppingListItemBuyShoppingListIdAsync(int shoppingListId)
    {
        var result = await _shoppingListItemService.GetShoppingListItemByShoppingListIdAsync(shoppingListId);
        if (result is null)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("DeleteShoppingListItemByShoppingListItemId")]
    public async Task<IActionResult> DeleteShoppingListItemByShoppingListItemIdAsync(int shoppingListItemId)
    {
      var result =  await _shoppingListItemService.DeleteShoppingListItemByShoppingListItemIdAsync(shoppingListItemId);
        return Ok(result);
    }

    [HttpDelete("DeleteShoppingListItemByShoppingListId")]
    public async Task<IActionResult> DeleteShoppingListItemByShoppingListIdAsync(int shoppingListId)
    {
        var result = await _shoppingListItemService.DeleteShoppingListItemByShoppingListIdAsync(shoppingListId);
        return Ok(result);
    }



}
