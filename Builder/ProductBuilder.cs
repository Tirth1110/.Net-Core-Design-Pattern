using Entity.Models;

namespace Builder;

public class ProductBuilder
{
    private readonly Product _product;

    public ProductBuilder(string name, decimal price)
    {
        _product = new Product
        {
            Name = name,
            Price = price
        };
    }

    public ProductBuilder SetDescription(string description)
    {
        _product.Description = description;
        return this;
    }

    public ProductBuilder SetDiscount(decimal discount)
    {
        _product.Discount = discount;
        return this;
    }

    public ProductBuilder SetCategory(string category)
    {
        _product.Category = category;
        return this;
    }

    public ProductBuilder SetTags(List<string> tags)
    {
        _product.Tags = tags;
        return this;
    }

    public Product Build()
    {
        return _product;
    }
}