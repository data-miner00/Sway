namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class ShoppingCartController : Controller
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

    public record AddToCartRequest(Guid ProductId, int Quantity);

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(
        AddToCartRequest request,
        [FromQuery] Guid userId)
    {
        if (!this.ModelState.IsValid)
        {
            this.TempData[Constants.Error] = "Failed adding item to cart.";
            return this.View(request);
        }

        await this.repository.AddItemIntoCartForUserAsync(
            userId.ToString(),
            request.ProductId.ToString(),
            request.Quantity,
            this.CancellationToken);

        this.TempData[Constants.Success] = "Successfully added item to cart.";

        return this.RedirectToAction(
            nameof(ProductController.Details),
            ProductController.ControllerName,
            new { id = request.ProductId });
    }
}
