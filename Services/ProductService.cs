using DTOs.Entity;

namespace Services;

public class ProductService : IProductService
{
    public Product CreateProduct(ProductCreateRequest request)
    {
        return new Product
        {
            Name = request.Name,
            Price = request.Price,
            Category = request.Category
        };
    }
}