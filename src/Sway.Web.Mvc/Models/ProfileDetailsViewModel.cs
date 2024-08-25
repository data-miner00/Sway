namespace Sway.Web.Mvc.Models;

using Sway.Core.Models;

public sealed class ProfileDetailsViewModel
{
    public User User { get; set; }

    public Address? ShippingAddress { get; set; }

    public Address? BillingAddress { get; set; }
}
