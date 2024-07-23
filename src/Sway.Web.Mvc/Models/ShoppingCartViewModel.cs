namespace Sway.Web.Mvc.Models;

using Sway.Core.Models;

public class ShoppingCartViewModel
{
    public Guid Id { get; set; }

    public IEnumerable<CartItem> CartItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
