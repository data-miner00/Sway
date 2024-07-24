namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;
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

        if (cart is null)
        {
            return this.View(cart);
        }

        var viewModel = new ShoppingCartViewModel
        {
            Id = cart.Id,
            CreatedAt = cart.CreatedAt,
            ModifiedAt = cart.ModifiedAt,
        };

        var items = await this.repository
            .GetCartItemsByUserIdAsync(Constants.TestUserId, this.CancellationToken)
            .ConfigureAwait(false);

        viewModel.CartItems = items;

        return this.View(viewModel);
    }
}
