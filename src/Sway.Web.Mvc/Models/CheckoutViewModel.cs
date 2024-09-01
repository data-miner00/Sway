namespace Sway.Web.Mvc.Models;

using Sway.Core.Dtos;
using Sway.Core.Models;

public class CheckoutViewModel
{
    public IEnumerable<CartItemDto> CartItems { get; set; }

    public Address ShippingAddress { get; set; }
}
