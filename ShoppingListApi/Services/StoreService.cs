using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Store;
using ShoppingListApi.Repositories.Interfaces;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Services;

public class StoreService : IStoreService
{
    private readonly IStoreRepository _repository;
    public StoreService(IStoreRepository repository)
    {
        _repository = repository;
        
    }
    public async Task<Store?> CreateStoreAsync(string userId, CreateStoreRequest request)
    {
        var store = new Store
        {
            StoreName = request.StoreName.Trim(),
             UserId = userId
           
        };

       return await _repository.CreateStoreAsync(userId, store);
    }

    public async Task<bool> DeleteStoreByIdAsync(string userId, int storId)
    {
      return  await _repository.DeleteStoreByIdAsync(userId, storId);

    }

    public async Task<Store?> GetStoreByIdAsync(int storeId)
    {
       return await _repository.GetStoreByIdAsync(storeId);
    }
    public Task<IEnumerable<Store>> GetStoresByStoreNameAsync(string userId, string storeName)
    {
       return _repository.GetStoreByStoreName(userId, storeName);
    }
}
