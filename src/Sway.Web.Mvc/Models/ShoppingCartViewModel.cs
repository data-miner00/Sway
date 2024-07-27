namespace Sway.Web.Mvc.Models;

using Sway.Core.Dtos;

public class ShoppingCartViewModel
{
    public Guid Id { get; set; }

    public IEnumerable<CartItemDto> CartItems { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime ModifiedAt { get; set; }
}
