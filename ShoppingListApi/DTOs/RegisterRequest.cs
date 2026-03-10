namespace ShoppingListApi.DTOs;

public class RegisterRequest
{
    public string Email { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int RoleId { get; set; }
}
