namespace Sway.Web.Mvc.Models;

using Sway.Core.Models;

public class ProductDetailsViewModel
{
    public Product Product { get; set; }

    public IEnumerable<ProductRating> Ratings { get; set; }
}
