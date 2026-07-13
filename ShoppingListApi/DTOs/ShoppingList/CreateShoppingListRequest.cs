using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.DTOs.ShoppingList;

public class CreateShoppingListRequest
{
    [Required]
    [StringLength(100)]
    public string Title { get; set; } = string.Empty;

    [Range(1, int.MaxValue)]
    public int StoreId { get; set; }

}
