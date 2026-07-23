using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Store;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
	[Authorize]
	public class StoreController : ApiBaseController
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService service)
        {
            _storeService = service;
        }

        [HttpGet("{storeId}")]
        public async Task<IActionResult> GetStoreByIdAsync(int storeId)
        {
            var result = await _storeService.GetStoreByIdAsync(storeId);
            if (result is null)
                return NotFound();
            return Ok(result);

        }

        [HttpGet("search")]
        public async Task<IActionResult> GetStoreByTitleAsync([FromQuery]string storeName)
        {
            if (UserId is null)
                return Unauthorized();

          var result = await _storeService.GetStoresByStoreNameAsync(UserId, storeName);
           return Ok(result);
            
        }

		[HttpPost]
        public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreRequest request)
        {
            if (request is null)
                return BadRequest();
            if (UserId is null)
                return Unauthorized();

            var result = await _storeService.CreateStoreAsync(UserId, request);
            //return CreatedAtRoute("GetStoreById", new { StoreId = result.StoreId }, result);
            if (result is null)
                return Conflict("Store already exists for this user.");
            return Ok(result);
        }

        [HttpDelete("{storeId}")]
        public async Task<IActionResult> DeleteStoreByIdAsync(int storeId)
        {
            if (UserId is null)
                return Unauthorized();

          var result= await _storeService.DeleteStoreByIdAsync(UserId, storeId);
            if (!result)
                return NotFound();
            return Ok(result);
            
        }

	}
}
