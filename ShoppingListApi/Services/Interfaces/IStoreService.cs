using Microsoft.AspNetCore.SignalR;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.Store;

namespace ShoppingListApi.Services.Interfaces;

public interface IStoreService
{
	Task<Store> CreateStoreAsync(String UserId,CreateStoreRequest request);
}
