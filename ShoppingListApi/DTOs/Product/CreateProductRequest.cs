using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.DTOs.Product
{
    public class CreateProductRequest
    {
		[Required]
		[StringLength(100)]
		public string Title { get; set; } = string.Empty;
		
		public int? CategoryId { get; set; }
	}
}
