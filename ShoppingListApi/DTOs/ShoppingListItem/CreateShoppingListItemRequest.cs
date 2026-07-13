using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.DTOs.ShoppingListItem;

public class CreateShoppingListItemRequest
{
    [Range(1, int.MaxValue)]
    public int ShoppingListId { get; set; }

    [Range(1, int.MaxValue)]
    public int ProductId { get; set; }

	[Range(0.01, 9999)]
	public decimal Quantity { get; set; } //1,2,5
	public UnitType Unit { get; set; } // "package","Kg","Liter"
	public bool IsChecked { get; set; }
}
