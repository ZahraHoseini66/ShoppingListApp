using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
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
    public DbSet<ShoppingList> ShoppingLists { get; set; }
    public DbSet<ShoppingListItem> ShoppingListItems { get; set; }
    public DbSet<ShoppingListUser> ShoppingListUsers { get; set; }
    public DbSet<Store> Stores { get; set; }

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
		builder.Entity<Store>().ToTable("Stores");

		builder.Entity<Product>()
            .HasOne(p => p.Category)
            .WithMany(c => c.Products)
            .HasForeignKey(p => p.CategoryId);

        builder.Entity<ShoppingList>()
            .HasOne(sh => sh.User)
            .WithMany(u => u.ShoppingLists)
            .HasForeignKey(sh => sh.UserId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<ShoppingList>()
            .HasMany(sh => sh.Items)
            .WithOne(item => item.ShoppingList)
            .HasForeignKey(item => item.ShoppingListId)
            .OnDelete(DeleteBehavior.Cascade);
        builder.Entity<ShoppingList>()
            .HasOne(sh => sh.Store)
            .WithMany(s => s.shoppingLists)
            .HasForeignKey(sh => sh.StoreId)
            .OnDelete(DeleteBehavior.Restrict);

        // ShoppingListUser → ShoppingList: cascade (deleting a list removes its shares)
        builder.Entity<ShoppingListUser>()
            .HasOne(su => su.ShoppingList)
            .WithMany()
            .HasForeignKey(su => su.ShoppingListId)
            .OnDelete(DeleteBehavior.Cascade);

        // ShoppingListUser → User: restrict to avoid multiple cascade paths
        builder.Entity<ShoppingListUser>()
            .HasOne(su => su.User)
            .WithMany()
            .HasForeignKey(su => su.UserId)
            .OnDelete(DeleteBehavior.Restrict);
        builder.Entity<Store>()
            .HasOne(s => s.User)
            .WithMany(user => user.Stores)
            .HasForeignKey(s => s.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<Store>()
            .HasIndex(s => new { s.UserId, s.StoreName })
            .IsUnique();



    }
}
