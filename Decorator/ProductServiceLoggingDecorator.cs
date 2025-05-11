using DTOs.Entity;
using Microsoft.Extensions.Logging;
using Services;

namespace Decorator;

public class ProductServiceLoggingDecorator(IProductService inner, ILogger<ProductServiceLoggingDecorator> logger)
        : IProductService
{
    private readonly IProductService _inner = inner;
    private readonly ILogger<ProductServiceLoggingDecorator> _logger = logger;

    public Product CreateProduct(ProductCreateRequest request)
    {
        _logger.LogInformation("Creating product: {Name}, Price: {Price}", request.Name, request.Price);

        var product = _inner.CreateProduct(request);

        _logger.LogInformation("Product created successfully: {Name}", product.Name);
        return product;
    }
}
