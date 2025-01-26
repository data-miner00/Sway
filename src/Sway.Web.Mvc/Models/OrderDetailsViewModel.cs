namespace Sway.Web.Mvc.Models;

using Sway.Core.Models;

public class OrderDetailsViewModel
{
    public Order Order { get; set; }

    public IEnumerable<OrderLine> OrderLines { get; set; }

    public OrderAddress OrderAddress { get; set; }

    public OrderPaymentMethod PaymentMethod { get; set; }
}
