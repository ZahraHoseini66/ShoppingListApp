using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShoppingListApi.DTOs.Product;
using ShoppingListApi.Services.Interfaces;

namespace ShoppingListApi.Controllers;


[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ProductController : ControllerBase
{
    private readonly IProductService _productService;
    public ProductController(IProductService productService )
    {
        _productService = productService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromBody] CreateProductRequest request)
    {
       var result = await _productService.CreateProductAsync(request);
		return Ok(result);
	}
   
    [HttpGet("{productId}")]
    public async Task<IActionResult> GetProductByIdAsync(int productId)
    {
       var result = await _productService.GetProductByIdAsync(productId);
        if (result == null) 
            return NotFound();  
   
       return Ok(result);
    }
   
    [HttpGet("search")]
    public async Task<IActionResult> GetProductsByTitleAsync([FromQuery]string title)
    {
        var result = await _productService.GetProductsByTitleAsync(title);
        return Ok(result);
    }
}

