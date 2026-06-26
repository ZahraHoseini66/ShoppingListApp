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

    //   [HttpGet]
    //public async Task<IActionResult> ShoppingLists()
    //{
    //       if (UserId is null)
    //           return Unauthorized();

    //       var lists = await _shoppingListRepository.GetByUserIdAsync(UserId);
    //       return Ok(lists);

    //}

    [HttpPost("CreateShoppingList")]
    [Authorize]
    public async Task<IActionResult> CreateShoppingListAsync([FromBody] CreateShoppingListRequest request)
    {
        if (request == null)
        
            return BadRequest();

        if (UserId is null)
            return Unauthorized();
        var result = await _shoppingListService.CreateShoppingListAsync(UserId, request);
        return CreatedAtAction(nameof(CreateShoppingListAsync), new { id = result.ShoppingListId }, result);

    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserIdAsync(string userId)
    {
        if (userId == null)
            return BadRequest();
        var result = await _shoppingListService.GetByUserIdAsync(userId);
        return Ok(result);


    }

}
