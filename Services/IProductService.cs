using DTOs.Entity;

namespace Services;
public interface IProductService
{
    Product CreateProduct(ProductCreateRequest request);
}