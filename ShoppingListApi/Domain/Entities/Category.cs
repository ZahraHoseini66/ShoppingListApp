using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.Domain.Entities;

public class Category
{
    [Key]
    public int CategoryId { get; set; }
    public string Title { get; set; }
    public List<Product> Products { get; set; } // Changed from private to public
}
