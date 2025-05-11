namespace Models;

public class DigitalProduct : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string GetProductType() => "Digital";
}
