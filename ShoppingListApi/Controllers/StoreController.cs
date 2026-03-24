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

        [HttpGet("GetStoreById")]
        public async Task<IActionResult> GetStoreByIdAsync(int storeId)
        {
            var result = await _storeService.GetStoreByIdAsync(storeId);
            if (result is null)
                return NotFound();
            return Ok(result);

        }
        [HttpGet("GetStoreByTitle")]
        public async Task<IActionResult> GetStoreByTitleAsync(string storeName)
        {
          var result = await _storeService.GetStoreByStoreName(storeName);
            if (result is null)
                return NotFound();
            return Ok(result);
            
        }

		[HttpPost("CreateStore")]
        public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreRequest request)
        {
            if (request is null)
                return BadRequest();
            if (UserId is null)
                return Unauthorized();

            var result = await _storeService.CreateStoreAsync(UserId, request);
            //return CreatedAtRoute("GetStoreById", new { StoreId = result.StoreId }, result);
            return Ok(result);
        }

        [HttpDelete("DeleteStoreById")]
        public async Task<IActionResult> DeleteStoreByIdAsync(int storeId)
        {
          var result= await _storeService.DeleteStoreByIdAsync(storeId);
            if (!result)
                return NotFound();
            return Ok(result);
            
        }

	}
}
