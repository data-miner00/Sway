namespace Sway.Core.Models;

public class Product
{
    public string Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int Stock { get; set; }

    public string SKU { get; set; }

    public string BrandId { get; set; }

    public string CategoryId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
