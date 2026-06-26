using System.ComponentModel.DataAnnotations;
using ShoppingListApi.Domain.Entities;
using ShoppingListApi.Domain.Enums;

namespace ShoppingListApi.DTOs.ShoppingList;

public class ShoppingListSearchRequest
{
	public int? ShoppingListId { get; set; }
	public DateTime? CreatedFromUtc { get; set; }
	public DateTime? CreatedToUtc { get; set; }

	public string? Title { get; set; }
	public ShoppingListStatus? Status { get; set; }
	public int? StoreId { get; set; }

	public int PageNumber { get; set; } = 1;
	public int PageSize { get; set; } = 20;


}
