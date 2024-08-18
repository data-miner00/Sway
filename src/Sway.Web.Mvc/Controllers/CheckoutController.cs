namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

public class CheckoutController : Controller
{
    private readonly IShoppingCartRepository repository;

    public CheckoutController(IShoppingCartRepository repository)
    {
        this.repository = repository;
    }

    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var items = await this.repository.GetCartItemsByUserIdAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(items);
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        return this.View();
    }
}
