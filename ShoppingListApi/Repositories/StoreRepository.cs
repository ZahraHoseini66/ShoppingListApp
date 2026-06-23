using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;


namespace ShoppingListApi.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _db;
    public StoreRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Store> CreateStoreAsync(Store store)
    {
        await _db.Stores.AddAsync(store);
        await _db.SaveChangesAsync();
        return store;
    }

    public async Task<bool> DeleteStoreByIdAsync(int StoreId)
    {
        var store = await GetStoreByIdAsync(StoreId);
        if (store is null)
            return false;
        _db.Stores.Remove(store);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Store?> GetStoreByIdAsync(int StoreId)
    {
        return await _db.Stores.Where(s => s.StoreId == StoreId).FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Store>> GetStoreByStoreName(string storeName)
    {
        return await _db.Stores.Where( s => s.StoreName.Contains(storeName.Trim('"'))).ToListAsync();
    }

}
