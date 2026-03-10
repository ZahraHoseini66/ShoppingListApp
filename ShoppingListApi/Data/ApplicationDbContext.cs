using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Data;

public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<ShoppingList> ShoppingLists  { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    public DbSet<ShoppingListUser> ShoppingListUsers { get; set; }
    public DbSet<ApplicationUser> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        // Explicit table names
        builder.Entity<Product>().ToTable("Products");
        builder.Entity<Category>().ToTable("Categories");
        builder.Entity<ShoppingList>().ToTable("ShoppingLists");
        builder.Entity<ShoppingListItem>().ToTable("ShoppingListItems");
        builder.Entity<ShoppingListUser>().ToTable("ShoppingListUsers");
        builder.Entity<ApplicationUser>().ToTable("Users");

        builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);
    }
}
