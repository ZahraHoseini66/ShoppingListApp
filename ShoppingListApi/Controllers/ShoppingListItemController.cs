using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.DTOs.ShoppingListItem;
using ShoppingListApi.Services;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ShoppingListItemController : ControllerBase
{
	private readonly IShoppingListItemService _shoppingListItemService;
    public ShoppingListItemController(IShoppingListItemService shoppingListItemService)
    {
        _shoppingListItemService = shoppingListItemService;
    }
    [HttpPost("CreateShoppingListItem")]
    [Authorize]
    public async Task<IActionResult> CreateShoppingListItemAsync([FromBody] CreateShoppingListItemRequest request)
    {
       var result = await _shoppingListItemService.CreateShoppingListItemAsync(request);
        return Ok(result);
    }


}
