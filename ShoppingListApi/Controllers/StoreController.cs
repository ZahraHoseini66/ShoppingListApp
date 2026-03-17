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
    public class StoreController :ApiBaseController
    {
        private readonly IStoreService _service;
        public StoreController(IStoreService service)
        {
            _service = service;
            
        }

        [HttpPost]
        [Authorize]
        public async Task<Store> CreateStoreAsync(string UserId, CreateStoreRequest request)
        {
          return await _service.CreateStoreAsync(UserId, request);
            
        }
    }
}
