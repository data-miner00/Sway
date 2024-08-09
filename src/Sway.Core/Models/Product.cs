namespace Sway.Core.Models;

public class Product
{
    public Guid Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public decimal Price { get; set; }

    public int InStock { get; set; }

    public string? SKU { get; set; }

    public float AverageRatings { get; set; }

    public Guid BrandId { get; set; }

    public Guid? CategoryId { get; set; }

    public int UnitsSold { get; set; }

    public string? DeliveryTime { get; set; }

    public int Favourite { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
