using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.DTOs.ShoppingListItem;

public class CreateShoppingListItemRequest
{
	public int ShoppingListId { get; set; }
	public int ProductId { get; set; }
	public decimal Quantity { get; set; } //1,2,5
	public UnitType Unit { get; set; } // "package","Kg","Liter"
	public bool IsChecked { get; set; }
}
