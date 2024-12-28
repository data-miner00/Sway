namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;
using System.ComponentModel.DataAnnotations;

public sealed class ShoppingCartController : Controller
{
    public const string ControllerName = "ShoppingCart";

    private readonly IShoppingCartRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ShoppingCartController"/> class.
    /// </summary>
    /// <param name="repository">The shopping cart repository.</param>
    public ShoppingCartController(IShoppingCartRepository repository)
    {
        this.repository = Guard.ThrowIfNull(repository);
    }

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

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
            .GetCartItemsByUserIdAsync(Constants.TestUserId, false, this.CancellationToken)
            .ConfigureAwait(false);

        viewModel.CartItems = items;

        return this.View(viewModel);
    }

    public sealed record AddToCartRequest(Guid ProductId, [Range(1, int.MaxValue)] int Quantity);

    [HttpPost]
    //[ValidateAntiForgeryToken]
    public async Task<IActionResult> AddToCart(
        AddToCartRequest request,
        [FromQuery] Guid userId)
    {
        if (!this.ModelState.IsValid)
        {
            this.TempData[Constants.Error] = "Failed adding item to cart.";
            return this.RedirectToAction(
                nameof(ProductController.Details),
                ProductController.ControllerName,
                new { id = request.ProductId });
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

    [HttpPost("ShoppingCart/IncrementCartItem/{cartItemId}")]
    public async Task<IActionResult> IncrementCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.IncrementCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }

    [HttpPost("ShoppingCart/DecrementCartItem/{cartItemId}")]
    public async Task<IActionResult> DecrementCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.DecrementCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }

    [HttpPost("[controller]/Delete/{cartItemId}")]
    public async Task<IActionResult> SoftDeleteCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.SoftDeleteCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }

    [HttpPost("[controller]/Undo/{cartItemId}")]
    public async Task<IActionResult> UndoDeletedCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.UndoDeletedCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }

    [HttpPost("[controller]/Select/{cartItemId}")]
    public async Task<IActionResult> SelectCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.SelectCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }

    [HttpPost("[controller]/Deselect/{cartItemId}")]
    public async Task<IActionResult> DeselectCartItem([FromRoute] Guid cartItemId)
    {
        await this.repository.DeselectCartItemAsync(cartItemId.ToString(), this.CancellationToken);

        return this.Ok();
    }
}
