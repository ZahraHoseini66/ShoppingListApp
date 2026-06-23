using Microsoft.AspNetCore.SignalR;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Store;

namespace ShoppingListApi.Services.Interfaces;

public interface IStoreService
{
	Task<Store> CreateStoreAsync(String userId,CreateStoreRequest request);
	Task<Store?> GetStoreByIdAsync(int  storeId);
	Task<IEnumerable<Store>> GetStoreByStoreName(string storeName);
	Task<bool> DeleteStoreByIdAsync(int storId);
}
