namespace Models;

public interface IProduct
{
    string Name { get; }
    decimal Price { get; }
    string GetProductType();
}