using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.Domain.Entities;

public class ShoppingList
{
    [Key]
    public int ShoppingListId { get; set; }
    public DateTime CreatedAt { get; set; }
    public string UserID { get; set; }
    public string Title { get; set; }
    public ShoppingListStatus Status { get; set; }

    // Navigation Property
    public ApplicationUser User { get; set; }
    public ICollection<ShoppingListItem> Items { get; set; } = [];


}
