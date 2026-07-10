using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.DTOs.ShoppingListItem;
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
    [HttpPost("UpdateCheckedStatus")]
    public async Task<IActionResult> UpdateCheckedStatusAsync( int shoppingListItemId, bool isChecked)
    {
        var result = await _shoppingListItemService.UpdateCheckedStatusAsync(shoppingListItemId, isChecked);
        if(!result)
            return NotFound();
        return Ok(result);
    }


}
