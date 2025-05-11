namespace Models;

public class PhysicalProduct : IProduct
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string GetProductType() => "Physical";
}
