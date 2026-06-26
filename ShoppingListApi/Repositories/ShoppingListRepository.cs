using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.DTOs.ShoppingList;
using ShoppingListApi.Repositories.Interfaces;

namespace ShoppingListApi.Repositories;

public class ShoppingListRepository : IShoppingListRepository
{
    private readonly ApplicationDbContext _db;
    public ShoppingListRepository(ApplicationDbContext db)
    {
        _db = db;
        
    }

    public async Task<ShoppingList> CreateShoppingListAsync(ShoppingList shoppingList)
    {
        await _db.ShoppingLists.AddAsync(shoppingList);
        await _db.SaveChangesAsync();
        return shoppingList;
    }

    public async Task<ShoppingList?> GetByShoppingListIdAsync(int shoppingListId)
    {
       return await _db.ShoppingLists.Where(s => s.ShoppingListId == shoppingListId).FirstOrDefaultAsync();
        
    }

    public async Task<IEnumerable<ShoppingList>> GetByUserIdAsync(string userId)
    {
        return await _db.ShoppingLists
            .Where(sh => sh.UserId == userId).ToListAsync();
    }

    public async Task<IEnumerable<ShoppingList>> SearchAsync(string userId, ShoppingListSearchRequest request)
    {
       var pageNumber = request.PageNumber <1 ? 1 : request.PageNumber;
       var pageSize = request.PageSize < 1 ? 20 : request.PageSize;
        pageSize = pageSize >100 ? 100 : pageSize;

        var query = _db.ShoppingLists
            .AsNoTracking()
            .Where(sh => sh.UserId == userId)
            .AsQueryable();
        if (request.ShoppingListId.HasValue)
            query = query.Where(sh => sh.ShoppingListId == request.ShoppingListId);
        if (request.Status.HasValue)
            query = query.Where(sh => sh.Status == request.Status.Value);
        if (request.CreatedFromUtc.HasValue)
            query = query.Where(sh => sh.CreatedAt >= request.CreatedFromUtc);
        if (request.CreatedToUtc.HasValue)
            query = query.Where(sh => sh.CreatedAt <= request.CreatedToUtc);
        
        var skip = (pageNumber - 1) * pageSize;

        return await query
            .OrderByDescending(sh => sh.CreatedAt )
            .Skip(skip)
            .Take(pageSize)
            .ToListAsync();
    }
}
