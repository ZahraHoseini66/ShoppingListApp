using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingListApi.Data;

namespace ShoppingListApi.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly ApplicationDbContext _db;
    public ProductController(ApplicationDbContext db )
    {
        _db = db;
    }
}
