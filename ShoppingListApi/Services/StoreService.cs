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
    public async Task<Store> CreateStoreAsync(string userId, CreateStoreRequest request)
    {
        var store = new Store
        {
            StoreName = request.StoreName,
             UserId = userId
           
        };

       return await _repository.CreateStoreAsync(store);
    }

    public async Task<bool> DeleteStoreByIdAsync(int storId)
    {
      return  await _repository.DeleteStoreByIdAsync(storId);

    }

    public async Task<Store?> GetStoreByIdAsync(int storeId)
    {
       return await _repository.GetStoreByIdAsync(storeId);
    }
    public Task<IEnumerable<Store>> GetStoresByStoreNameAsync(string storeName)
    {
       return _repository.GetStoreByStoreName(storeName);
    }
}
