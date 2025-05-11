namespace Models;

public class ProductCreateRequest
{
    public string Type { get; set; } // "physical" or "digital"
    public string Name { get; set; }
    public decimal Price { get; set; }
}