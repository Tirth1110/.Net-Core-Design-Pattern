using Builder;
using Entity.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bulider_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult Create([FromBody] ProductCreateRequest request)
        {
            ProductBuilder? builder = new ProductBuilder(request.Name, request.Price);

            if (!string.IsNullOrWhiteSpace(request.Description))
                builder.SetDescription(request.Description);

            if (request.Discount.HasValue)
                builder.SetDiscount(request.Discount.Value);

            if (!string.IsNullOrWhiteSpace(request.Category))
                builder.SetCategory(request.Category);

            if (request.Tags is not null && request.Tags.Count is not 0)
                builder.SetTags(request.Tags);

            Product? product = builder.Build();

            return Ok(product);
        }
    }
}
