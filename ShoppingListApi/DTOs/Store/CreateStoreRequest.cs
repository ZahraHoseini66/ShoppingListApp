using System.ComponentModel.DataAnnotations;

namespace ShoppingListApi.DTOs.Store;

public class CreateStoreRequest
{
	[Required]
	[StringLength(100)]
	public string StoreName { get; set; }	= string.Empty;
}
