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
    public class StoreController : ApiBaseController
    {
        private readonly IStoreService _storeService;
        public StoreController(IStoreService service)
        {
            _storeService = service;
        }

        [HttpGet("{StoreId}", Name = "GetStoreById")]
        [Authorize]
        public async Task<IActionResult> GetStoreByIdAsync(int StoreId)
        {
            var result = await _storeService.GetStoreByIdAsync(StoreId);
            if (result is null)
                return NotFound();
            return Ok(result);
        }

        [HttpPost("CreateStore")]
        [Authorize]
        public async Task<IActionResult> CreateStoreAsync([FromBody] CreateStoreRequest request)
        {
            if (request is null)
                return BadRequest();
            if (UserId is null)
                return Unauthorized();

            var result = await _storeService.CreateStoreAsync(UserId, request);
            return CreatedAtRoute("GetStoreById", new { StoreId = result.StoreId }, result);
        }
    }
}
