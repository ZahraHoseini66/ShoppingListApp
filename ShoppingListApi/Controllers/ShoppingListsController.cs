using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingListsController : ControllerBase
{
    private readonly IShoppingListRepository _shoppingListRepository;
    public ShoppingListsController(IShoppingListRepository shoppingListRepository)
    {
      _shoppingListRepository = shoppingListRepository;  
    }

    [HttpGet]
	public async Task<IActionResult> ShoppingLists()
	{
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
        if (userId is null)
            return Unauthorized();

        var lists = await _shoppingListRepository.GetByUserIdAsync(userId);
        return Ok(lists);

	}

    //[HttpPost]
    //public async
}
