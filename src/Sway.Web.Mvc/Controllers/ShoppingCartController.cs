﻿namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class ShoppingCartController : Controller
{
    private readonly IShoppingCartRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ShoppingCartController(IShoppingCartRepository repository)
    {
        this.repository = Guard.ThrowIfNull(repository);
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

    public sealed record AddToCartRequest(Guid ProductId, int Quantity);

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
}
