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
    public async Task<Store> CreateStoreAsync(string UserId, CreateStoreRequest request)
    {
        var store = new Store
        {
            StoreName = request.StoreName
           
        };

       return await _repository.CreateStoreAsync(store);
    }

    public async Task<Store> GetStoreByIdAsync(int StoreId)
    {
       return await _repository.GetStoreByIdAsync(StoreId);
    }
}
