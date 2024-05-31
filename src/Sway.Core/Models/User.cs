namespace Sway.Core.Models;

using System;

public class User
{
    public string Id { get; set; }

    public string Name { get; set; }

    public Status Status { get; set; }

    public Role Role { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Description { get; set; }

    public string ShippingAddressId { get; set; }

    public string BillingAddressId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
