﻿namespace Sway.Core.Models;

public class Coupon
{
    public Guid Id { get; set; }

    public Guid? OwnerId { get; set; }

    public string Code { get; set; }

    public string? Description { get; set; }

    public decimal DiscountAmount { get; set; }

    public DiscountType Type { get; set; }

    public Guid? ApplicableFor { get; set; }

    public Guid? AppliedToOrder { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
