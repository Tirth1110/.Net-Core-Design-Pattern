using Models;

namespace Factory;

public class ProductFactory : IProductFactory
{
    public IProduct CreateProduct(string type, string name, decimal price)
    {
        return type.ToLower() switch
        {
            "physical" => new PhysicalProduct { Name = name, Price = price },
            "digital" => new DigitalProduct { Name = name, Price = price },
            _ => throw new ArgumentException("Invalid product type")
        };
    }
}