namespace Sway.Core.Models;

public class PaymentMethod
{
    public int Id { get; set; }

    public string UserId { get; set; }

    public PaymentType Type { get; set; }

    public string? Provider { get; set; }

    public string? AccountNo { get; set; }

    public DateTime? ExpiryDate { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
