using Models;

namespace Factory;

public interface IProductFactory
{
    IProduct CreateProduct(string type, string name, decimal price);
}
