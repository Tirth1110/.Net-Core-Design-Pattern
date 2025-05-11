using Factory;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Factory_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFactory _productFactory;

        public ProductsController(IProductFactory productFactory)
        {
            _productFactory = productFactory;
        }

        [HttpPost("create")]
        public IActionResult CreateProduct([FromBody] ProductCreateRequest request)
        {
            IProduct? product = _productFactory.CreateProduct(request.Type, request.Name, request.Price);
            return Ok(new
            {
                product.Name,
                product.Price,
                Type = product.GetProductType()
            });
        }
    }
}
