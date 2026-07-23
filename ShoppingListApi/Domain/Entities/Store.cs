using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.Domain.Entities;

public class Store
{
    [Key]
    public int StoreId { get; set; }
    [Required]
    [StringLength(100)]
    public string StoreName { get; set; } = string.Empty;

    // null means this is a public/system store
    public string? UserId { get; set; }
    public ApplicationUser? User { get; set; }

    public ICollection<ShoppingList> shoppingLists { get; set; } = [];
}
