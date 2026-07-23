using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.Data;

public static class DevelopmentDataSeeder
{
    private const string DemoUserEmail = "demo@shoppinglist.local";
    private const string DemoUserPassword = "Demo@123";

    public static async Task SeedAsync(
        ApplicationDbContext dbContext,
        UserManager<ApplicationUser> userManager)
    {
        var demoUser = await userManager.FindByEmailAsync(DemoUserEmail);
        if (demoUser is null)
        {
            demoUser = new ApplicationUser
            {
                UserName = DemoUserEmail,
                Email = DemoUserEmail,
                EmailConfirmed = true,
                FirstName = "Demo",
                LastName = "User",
                CreateAt = DateTime.UtcNow,
                RoleId = 1
            };

            var createUserResult = await userManager.CreateAsync(demoUser, DemoUserPassword);
            if (!createUserResult.Succeeded)
            {
                var errors = string.Join(", ", createUserResult.Errors.Select(error => error.Description));
                throw new InvalidOperationException($"Failed to create development demo user: {errors}");
            }
        }

        var publicStoreNames = new[]
{
        "Penny",
        "Lidl",
        "Aldi",
        "Rewe"
};

        foreach (var storeName in publicStoreNames)
        {
            var exists = await dbContext.Stores.AnyAsync(store =>
                store.UserId == null &&
                store.StoreName == storeName);

            if (!exists)
            {
                dbContext.Stores.Add(new Store
                {
                    StoreName = storeName,
                    UserId = null
                });
            }
        }
        if (!await dbContext.Products.AnyAsync(product => product.Title == "Milk"))
            dbContext.Products.Add(new Product { Title = "Milk" });

        if (!await dbContext.Products.AnyAsync(product => product.Title == "Bread"))
            dbContext.Products.Add(new Product { Title = "Bread" });

        if (!await dbContext.Products.AnyAsync(product => product.Title == "Eggs"))
            dbContext.Products.Add(new Product { Title = "Eggs" });

        await dbContext.SaveChangesAsync();

        var demoStore = await dbContext.Stores
    .FirstAsync(store =>
        store.UserId == null &&
        store.StoreName == "Aldi");

        var demoProducts = await dbContext.Products
            .Where(product => product.Title == "Milk" || product.Title == "Bread" || product.Title == "Eggs")
            .ToListAsync();

        if (!await dbContext.ShoppingLists.AnyAsync(shoppingList =>
                shoppingList.UserId == demoUser.Id &&
                shoppingList.Title == "Demo grocery list"))
        {
            var demoShoppingList = new ShoppingList
            {
                Title = "Demo grocery list",
                UserId = demoUser.Id,
                StoreId = demoStore.StoreId,
                Status = ShoppingListStatus.Active,
                CreatedAt = DateTime.UtcNow
            };

            dbContext.ShoppingLists.Add(demoShoppingList);
            await dbContext.SaveChangesAsync();

            var milk = demoProducts.First(product => product.Title == "Milk");
            var bread = demoProducts.First(product => product.Title == "Bread");
            var eggs = demoProducts.First(product => product.Title == "Eggs");

            dbContext.ShoppingListItems.AddRange(
                new ShoppingListItem
                {
                    ShoppingListId = demoShoppingList.ShoppingListId,
                    ProductId = milk.ProductId,
                    Quantity = 2,
                    Unit = UnitType.Liter,
                    IsChecked = false
                },
                new ShoppingListItem
                {
                    ShoppingListId = demoShoppingList.ShoppingListId,
                    ProductId = bread.ProductId,
                    Quantity = 1,
                    Unit = UnitType.Package,
                    IsChecked = false
                },
                new ShoppingListItem
                {
                    ShoppingListId = demoShoppingList.ShoppingListId,
                    ProductId = eggs.ProductId,
                    Quantity = 12,
                    Unit = UnitType.Piece,
                    IsChecked = true
                });

            await dbContext.SaveChangesAsync();
        }
    }
}
