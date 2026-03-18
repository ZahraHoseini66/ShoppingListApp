using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IStoreRepository
{
	Task<Store> CreateStoreAsync(Store store);
	Task<Store> GetStoreByIdAsync(int StoreId);
}
