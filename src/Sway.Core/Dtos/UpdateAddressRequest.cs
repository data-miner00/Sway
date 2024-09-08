namespace Sway.Core.Dtos;

public class UpdateAddressRequest
{
    public string Id { get; set; }

    public string Street1 { get; set; }

    public string? Street2 { get; set; }

    public string City { get; set; }

    public string? State { get; set; }

    public string Postcode { get; set; }

    public string Country { get; set; }

    public bool IsDefault { get; set; }
}
