using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.Domain.Entities;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    public string Title { get; set; } = string.Empty;
    public int? CategoryId { get; set; }

    // Navigation Property
    public Category Category { get; set; } = null;
}
