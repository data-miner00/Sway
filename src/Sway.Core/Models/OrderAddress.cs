namespace Sway.Core.Models;

using System;

/// <summary>
/// The address info for an order.
/// </summary>
public class OrderAddress
{
    /// <summary>
    /// Gets or sets the unique identifier.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the address type.
    /// </summary>
    public AddressType Type { get; set; }

    /// <summary>
    /// Gets or sets the first street of the address.
    /// </summary>
    public string Street1 { get; set; }

    /// <summary>
    /// Gets or sets the second street of the address.
    /// </summary>
    public string? Street2 { get; set; }

    /// <summary>
    /// Gets or sets the city of the address.
    /// </summary>
    public string City { get; set; }

    /// <summary>
    /// Gets or sets the state of the address.
    /// </summary>
    public string? State { get; set; }

    /// <summary>
    /// Gets or sets the postcode of the address.
    /// </summary>
    public string Postcode { get; set; }

    /// <summary>
    /// Gets or sets the country of the address.
    /// </summary>
    public string Country { get; set; }

    /// <summary>
    /// Gets or sets the created date.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the modified date.
    /// </summary>
    public DateTime ModifiedAt { get; set; }

    /// <summary>
    /// Gets or sets the order Id for this address.
    /// </summary>
    public Guid OrderId { get; set; }

    /// <inheritdoc/>
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
