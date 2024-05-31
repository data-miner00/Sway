namespace Sway.Core.Models;

using System;

public class Address
{
    public string Id { get; set; }

    public AddressType Type { get; set; }

    public string Street1 { get; set; }

    public string? Street2 { get; set; }

    public string City { get; set; }

    public string? State { get; set; }

    public string PostalCode { get; set; }

    public string Country { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
