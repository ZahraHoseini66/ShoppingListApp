using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.Domain.Entities;

public class ShoppingListUser
{
    [Key]
    public int ShoppingListUserId { get; set; }
    public int ShoppingListId { get; set; }
    public string UserId { get; set; }
    public PermissionLevel PermissionLevel { get; set; }
    public DateTime SharedAt { get; set; }

    // Navigation Properties
    public ShoppingList ShoppingList { get; set; }
    public ApplicationUser User { get; set; }
}