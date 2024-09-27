namespace Sway.Web.Mvc.Models;

using Sway.Core.Dtos;
using Sway.Core.Models;

public sealed class CheckoutViewModel
{
    public IEnumerable<CartItemDto> CartItems { get; set; }

    public Address ShippingAddress { get; set; }

    public IEnumerable<PaymentMethod> PaymentMethods { get; set; }
}
