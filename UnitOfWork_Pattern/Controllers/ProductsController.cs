using Entity;
using Microsoft.AspNetCore.Mvc;
using UnitOfWork;

namespace UnitOfWork_Pattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController(IUnitOfWorkRepository unitOfWork) : ControllerBase
    {
        private readonly IUnitOfWorkRepository _unitOfWork = unitOfWork;

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            IEnumerable<Product>? products = await _unitOfWork.Products.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            Product? product = await _unitOfWork.Products.GetByIdAsync(id);
            return product == null ? NotFound() : Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Product product)
        {
            await _unitOfWork.Products.AddAsync(product);
            await _unitOfWork.SaveAsync();
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product updated)
        {
            Product? existing = await _unitOfWork.Products.GetByIdAsync(id);
            if (existing == null) return NotFound();

            existing.Name = updated.Name;
            existing.Price = updated.Price;

            _unitOfWork.Products.Update(existing);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product? existing = await _unitOfWork.Products.GetByIdAsync(id);
            if (existing == null) return NotFound();

            _unitOfWork.Products.Delete(existing);
            await _unitOfWork.SaveAsync();

            return NoContent();
        }
    }
}