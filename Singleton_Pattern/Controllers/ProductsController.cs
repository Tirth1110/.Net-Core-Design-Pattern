using DTOs;
using Microsoft.AspNetCore.Mvc;
using Service;

namespace Singleton_Pattern.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController(IProductLogger logger) : ControllerBase
{
    private readonly IProductLogger _logger = logger;

    [HttpPost("create")]
    public IActionResult Create([FromBody] ProductCreateRequest request)
    {
        _logger.Log($"Created product: {request.Name}, Price: {request.Price}");
        return Ok(request);
    }

    [HttpGet("logs")]
    public IActionResult GetLogs()
    {
        return Ok(_logger.GetLogs());
    }
}