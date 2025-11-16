namespace Sway.Core.Models;

/// <summary>
/// The coupon model representing discount coupons in the system.
/// </summary>
public class Coupon
{
    /// <summary>
    /// Gets or sets the unique identifier for the coupon.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the unique identifier of the owner.
    /// </summary>
    public Guid? OwnerId { get; set; }

    /// <summary>
    /// Gets or sets the unique code for the coupon.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the description of the coupon.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets or sets the discount amount provided by the coupon.
    /// </summary>
    public decimal DiscountAmount { get; set; }

    /// <summary>
    /// Gets or sets the type of discount (e.g., flat amount or percentage).
    /// </summary>
    public DiscountType DiscountUnit { get; set; }

    /// <summary>
    /// Gets or sets the brand identifier for which the coupon is applicable.
    /// </summary>
    public Guid? ApplicableForBrand { get; set; }

    /// <summary>
    /// Gets or sets the order identifier to which the coupon has been applied.
    /// </summary>
    public Guid? AppliedToOrder { get; set; }

    /// <summary>
    /// Gets or sets the expiration date and time of the coupon.
    /// </summary>
    public DateTime? ExpireAt { get; set; }

    /// <summary>
    /// Gets or sets the creation date and time of the coupon.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the last modification date and time of the coupon.
    /// </summary>
    public DateTime ModifiedAt { get; set; }
}
