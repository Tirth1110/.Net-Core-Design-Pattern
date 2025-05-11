namespace DTOs.Entity;

public class ProductCreateRequest
{
    public string Name { get; set; }
    public decimal Price { get; set; }
    public string? Category { get; set; }
}
