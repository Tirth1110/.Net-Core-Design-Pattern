namespace Entity.Models;

public class Product
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Description { get; set; }
    public decimal? Discount { get; set; }
    public string? Category { get; set; }
    public List<string>? Tags { get; set; }

    public override string ToString()
    {
        return $"{Name} (${Price}) - {Category} - Discount: {Discount}%";
    }
}
