using ShoppingListApi.DTOs.ShoppingListItem;

namespace ShoppingListApi.DTOs.ShoppingList
{
    public class ShoppingListDetailsResponse
    {
        public int ShoppingListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public List<ShoppingListItemResponse> Items { get; set; } = [];
    }
}
