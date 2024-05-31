namespace Sway.Core.Models;

public class Coupon
{
    public int Id { get; set; }

    public string? OwnerId { get; set; }

    public string Code { get; set; }

    public string? Description { get; set; }

    public decimal DiscountAmount { get; set; }

    public DiscountType Type { get; set; }

    public string? ApplicableFor { get; set; }

    public string? AppliedToOrder { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
