namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using System.Data;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartRepository repository;

    // temporary
    private string UserId => "2BA7AD7C-4731-43BF-AE9C-28B0BD2B0095";

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ShoppingCartController(IShoppingCartRepository repository)
    {
        this.repository = repository;
    }

    // GET: ShoppingCartController
    public async Task<IActionResult> Index()
    {
        var cart = await this.repository
            .GetByUserIdAsync(this.UserId, this.CancellationToken)
            .ConfigureAwait(false);

        return this.View(cart);
    }
}
