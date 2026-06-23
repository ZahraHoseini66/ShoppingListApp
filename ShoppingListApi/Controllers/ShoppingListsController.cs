using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.Repositories.Interfaces;
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

    [HttpPost("CreateShoppingList")]
    [Authorize]
    public async Task<IActionResult> CreateShoppingListAsync([FromBody] CreateShoppingListRequest request)
    {
        if (request == null)

            return BadRequest();

        if (UserId is null)
            return Unauthorized();
        var result = await _shoppingListService.CreateShoppingListAsync(UserId, request);
        return Ok(result);
    }
    [HttpGet("Search")]
    public async Task<IActionResult> SearchAsync([FromQuery]ShoppingListSearchRequest request)
    {
       if(request == null)
            return BadRequest();
       if(UserId is null)
            return Unauthorized();
       var result = await _shoppingListService.SearchAsync(UserId, request);
        return Ok(result);
    }

    [HttpGet("GetByShoppingListId")]
    public async Task<IActionResult> GetByShoppingListIdAsync(int shoppingListId)
    {
        if (shoppingListId == null)
            return BadRequest();
       var result = await _shoppingListService.GetByShoppingListIdAsync(shoppingListId);
        return Ok(result);

    }

    [HttpGet("GetByUserId")]
    public async Task<IActionResult> GetByUserIdAsync(string userId)
    {
        if (userId == null)
            return BadRequest();
        var result = await _shoppingListService.GetByUserIdAsync(userId);
        return Ok(result);


    }

}
