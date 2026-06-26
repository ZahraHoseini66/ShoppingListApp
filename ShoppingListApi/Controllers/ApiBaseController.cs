using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ShoppingListApi.Controllers;

[Authorize]
public class ApiBaseController : ControllerBase
{
	protected string? UserId => User.FindFirstValue(ClaimTypes.NameIdentifier);
}
