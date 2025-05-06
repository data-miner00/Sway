namespace Sway.Web.Mvc.Models;

using Sway.Core.Models;

public class ProductSearchViewModel
{
    public IEnumerable<Product> Results { get; set; }

    public string SearchTerm { get; set; }
}
