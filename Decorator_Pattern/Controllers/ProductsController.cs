using DTOs.Entity;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace Decorator_Pattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductService productService) : ControllerBase
{
    private readonly IProductService _productService = productService;

    [HttpPost("create")]
    public IActionResult Create([FromBody] ProductCreateRequest request)
    {
        Product? product = _productService.CreateProduct(request);
        return Ok(product);
    }
}