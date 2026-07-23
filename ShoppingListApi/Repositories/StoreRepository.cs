using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;


namespace ShoppingListApi.Repositories;

public class StoreRepository : IStoreRepository
{
    private readonly ApplicationDbContext _db;
    public StoreRepository(ApplicationDbContext db)
    {
        _db = db;
    }
    public async Task<Store?> CreateStoreAsync(string userId, Store store)
    {
        bool storeIsExist = await StoreExistsForUserAsync(userId, store.StoreName);
        if (!storeIsExist)
        {
            await _db.Stores.AddAsync(store);
            await _db.SaveChangesAsync();
            return store;
        }
        return null;
    }

    public async Task<bool> DeleteStoreByIdAsync(string userId, int storeId)
    {

        var store = await _db.Stores.Where(s => s.StoreId == storeId && s.UserId == userId).FirstOrDefaultAsync();
        if (store is null)
            return false;
        _db.Stores.Remove(store);
        await _db.SaveChangesAsync();
        return true;
    }

    public async Task<Store?> GetStoreByIdAsync(int storeId)
    {
        return await _db.Stores.Where(s => s.StoreId == storeId).FirstOrDefaultAsync();
    }
    public async Task<IEnumerable<Store>> GetStoreByStoreName(string userId, string storeName)
    {
        return await _db.Stores.Where(s => (s.UserId == null || s.UserId == userId)
        && s.StoreName.Contains(storeName.Trim('"'))).OrderBy(store => store.UserId == null ? 0 : 1)
        .ThenBy(store => store.StoreName).ToListAsync();
    }
    public async Task<bool> StoreExistsForUserAsync(string userId, string storeName)
    {
        return await _db.Stores.AnyAsync(s => s.UserId == userId && s.StoreName == storeName);

    }
}
