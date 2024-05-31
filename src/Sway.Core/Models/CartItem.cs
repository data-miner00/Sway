namespace Sway.Core.Models;

public class CartItem
{
    public string Id { get; set; }

    public string CartId { get; set; }

    public string ProductId { get; set; }

    public int Quantity { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
