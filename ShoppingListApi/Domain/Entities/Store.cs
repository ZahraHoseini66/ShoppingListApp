using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.Domain.Entities;

public class Store
{
    [Key]
    public int StoreId { get; set; }
    public string StoreName { get; set; }
    public string UserId { get; set; }
    // Navigation Property
    public ICollection<ShoppingList> shoppingLists { get; set; } = [];
}
