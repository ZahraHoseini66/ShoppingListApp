using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.DTOs.ShoppingList
{
    public class ShoppingListSummaryResponse
    {
        public int ShoppingListId { get; set; }
        public string Title { get; set; } = string.Empty;
        public int StoreId { get; set; }
        public ShoppingListStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
