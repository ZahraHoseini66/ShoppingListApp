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
    public async Task<Store> CreateStoreAsync(Store store)
    {
        await _db.Stores.AddAsync(store);
        await _db.SaveChangesAsync();
        return store;
    }
}
