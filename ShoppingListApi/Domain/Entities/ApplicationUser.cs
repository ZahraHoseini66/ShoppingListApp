using Microsoft.AspNetCore.Identity;
using ShoppingListApi.Domain.Enums;
using ShoppingListApi.Domain.Entities;

namespace ShoppingListApi.Domain.Entities;

public class ApplicationUser : IdentityUser
{
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public DateTime CreateAt { get; set; }
	public int RoleId { get; set; }

	// Navigation Properties
	public ICollection<ShoppingList> ShoppingLists { get; set; } = [];
    public ICollection<Store> Stores { get; set; } = [];

}
