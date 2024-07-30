namespace Sway.Core.Models;

using System;

public class User
{
    public Guid Id { get; set; }

    public string Username { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public Status Status { get; set; }

    public Role Role { get; set; }

    public string Email { get; set; }

    public string Phone { get; set; }

    public string? PhotoUrl { get; set; }

    public string? Description { get; set; }

    public Guid ShippingAddressId { get; set; }

    public Guid BillingAddressId { get; set; }

    public DateTime DateOfBirth { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
