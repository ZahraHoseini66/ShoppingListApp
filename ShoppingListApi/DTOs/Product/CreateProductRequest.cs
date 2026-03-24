namespace ShoppingListApi.DTOs.Product
{
    public class CreateProductRequest
    {
		public string Title { get; set; } = string.Empty;
		public int? CategoryId { get; set; }
	}
}
