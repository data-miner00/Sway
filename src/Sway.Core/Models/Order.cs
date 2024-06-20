namespace Sway.Core.Models;

public class Order
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public OrderStatus Status { get; set; }

    public double TotalAmount { get; set; }

    public string Currency { get; set; }

    public string PaymentInfoId { get; set; }

    public string ShippingAddressId { get; set; }

    public string BillingAddressId { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }
}
