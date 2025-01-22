namespace Sway.Core.Models;

public class Order
{
    public Guid Id { get; set; }

    public Guid UserId { get; set; }

    public OrderStatus Status { get; set; }

    public decimal TotalAmount { get; set; }

    public string Currency { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
