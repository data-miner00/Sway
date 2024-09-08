namespace Sway.Core.Models;

using System;

public class Address
{
    public Guid Id { get; set; }

    public AddressType Type { get; set; }

    public string Street1 { get; set; }

    public string? Street2 { get; set; }

    public string City { get; set; }

    public string? State { get; set; }

    public string Postcode { get; set; }

    public string Country { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }

    public Guid UserId { get; set; }

    public bool IsDefault { get; set; }

    public override string ToString()
    {
        List<string> elements = [
            this.Street1,
            this.Street2,
            this.City,
            this.State,
            this.Postcode,
            this.Country,
        ];

        return string.Join(", ", elements.Where(x => !string.IsNullOrWhiteSpace(x)));
    }
}
