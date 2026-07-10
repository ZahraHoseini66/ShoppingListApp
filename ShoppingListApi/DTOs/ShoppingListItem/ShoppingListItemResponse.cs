using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.DTOs.ShoppingListItem
{
    public class ShoppingListItemResponse
    {
        public int ShoppingListItemId { get; set; }
        public int ProductId { get; set; }
        public decimal Quantity { get; set; }
        public UnitType Unit  { get; set; }
        public bool IsChecked { get; set; }
    }
}
