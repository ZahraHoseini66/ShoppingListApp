using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ShoppingListsController : ApiBaseController
{
    private readonly IShoppingListRepository _shoppingListRepository;
    public ShoppingListsController(IShoppingListRepository shoppingListRepository)
    {
      _shoppingListRepository = shoppingListRepository;  
    }

    //   [HttpGet]
    //public async Task<IActionResult> ShoppingLists()
    //{
    //       if (UserId is null)
    //           return Unauthorized();

    //       var lists = await _shoppingListRepository.GetByUserIdAsync(UserId);
    //       return Ok(lists);

    //}

    //[HttpPost]
    //public IActionResult CreateShoppingList([FromBody] ShoppingList shoppingList)
    //{
    //    if (shoppingList == null)
    //    {
    //        return BadRequest();
    //    }
    //}
}
