using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingListsController : ApiBaseController
{
	private readonly IShoppingListService _shoppingListService;
	public ShoppingListsController(IShoppingListService shoppingListService)
	{
		_shoppingListService = shoppingListService;
	}

    [HttpPost]
	public async Task<IActionResult> CreateShoppingListAsync([FromBody] CreateShoppingListRequest request)
	{
		if (request == null)

			return BadRequest();

		if (UserId is null)
			return Unauthorized();
		var result = await _shoppingListService.CreateShoppingListAsync(UserId, request);
		return Ok(result);	

	}
	
	[HttpGet]
	public async Task<IActionResult> GetMyShoppingListsAsync()
	{
		if (UserId is null)
			return Unauthorized();
		var result = await _shoppingListService.GetShoppingListsByUserIdAsync(UserId);
		
		return Ok(result);
	}

	[HttpGet("{shoppingListId}")]
	public async Task<IActionResult> GetShoppingListByShoppingListIdAsync(int shoppingListId)
	  {
		if(UserId is null)
			return Unauthorized();
		var result = await _shoppingListService.GetShoppingListsByShoppingListIdAsync(UserId, shoppingListId);
		if(result == null)
			return NotFound();
		return Ok(result);

    }
}
