using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Repositories.Interfaces;

public interface IStoreRepository
{
	Task<Store?> CreateStoreAsync(string userId, Store store);
	Task<Store?> GetStoreByIdAsync(int storeId);
	Task<IEnumerable<Store>> GetStoreByStoreName(string userId, string storeName);
	Task<bool> DeleteStoreByIdAsync(string userId, int storeId);
}
