using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.Domain.Entities;

public class ShoppingListItem
{
    [Key]
    public int ShoppingListItemId { get; set; }
    public int ShoppingListId { get; set; }
    public int ProductId { get; set; }
    public decimal Quantity { get; set; } //1,2,5
    public UnitType Unit { get; set; } // "package","Kg","Liter"

    public bool IsChecked { get; set; }
    // Navigation Propertys
    public ShoppingList ShoppingList { get; set; }
    public Product Product { get; set; }

}
