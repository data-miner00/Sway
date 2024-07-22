namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using System.Data;

public class ShoppingCartController : Controller
{
    private readonly IShoppingCartRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ShoppingCartController(IShoppingCartRepository repository)
    {
        this.repository = repository;
    }

    // GET: ShoppingCartController
    public async Task<IActionResult> Index()
    {
        var cart = await this.repository
            .GetByUserIdAsync(Constants.TestUserId, this.CancellationToken)
            .ConfigureAwait(false);

        return this.View(cart);
    }
}
