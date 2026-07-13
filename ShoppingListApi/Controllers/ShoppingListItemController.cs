using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingListItemController : ApiBaseController
{
	private readonly IShoppingListItemService _shoppingListItemService;
    public ShoppingListItemController(IShoppingListItemService shoppingListItemService)
    {
        _shoppingListItemService = shoppingListItemService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateShoppingListItemAsync([FromBody] CreateShoppingListItemRequest request)
    {
       var result = await _shoppingListItemService.CreateShoppingListItemAsync(request);
        return Ok(result);
    }

    [HttpPost("{shoppingListItemId}/checked")]
    public async Task<IActionResult> UpdateCheckedStatusAsync( int shoppingListItemId, bool isChecked)
    {
       if(UserId is null)
            return Unauthorized();
        var result = await _shoppingListItemService.UpdateCheckedStatusAsync(UserId, shoppingListItemId, isChecked);
        if(!result)
            return NotFound();
        return Ok(result);
    }

    [HttpDelete("{shoppingListItemId}")]
    public async Task<IActionResult> DeleteShoppingListItemAsync(int shoppingListItemId)
    {
        if (UserId is null)
            return Unauthorized();
        var result = await _shoppingListItemService.DeleteShoppingListItemAsync(UserId, shoppingListItemId);
        if (!result)
            return NotFound();
        return Ok(result);
    }


}
