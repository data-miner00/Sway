namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class CheckoutController : Controller
{
    private readonly IShoppingCartRepository cartRepository;
    private readonly IAddressRepository addressRepository;
    private readonly IPaymentMethodRepository paymentMethodRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckoutController"/> class.
    /// </summary>
    /// <param name="cartRepository">The cart repository.</param>
    /// <param name="addressRepository">The address repository.</param>
    /// <param name="paymentMethodRepository">The payment repository.</param>
    public CheckoutController(
        IShoppingCartRepository cartRepository,
        IAddressRepository addressRepository,
        IPaymentMethodRepository paymentMethodRepository)
    {
        this.cartRepository = Guard.ThrowIfNull(cartRepository);
        this.addressRepository = Guard.ThrowIfNull(addressRepository);
        this.paymentMethodRepository = Guard.ThrowIfNull(paymentMethodRepository);
    }

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var userId = Constants.TestUserId;

        var items = await this.cartRepository.GetCartItemsByUserIdAsync(userId, true, this.CancellationToken);
        var addresses = await this.addressRepository.GetAllByUserAsync(userId, this.CancellationToken);
        var payments = await this.paymentMethodRepository
            .GetAllByUserAsync(userId, this.CancellationToken)
            .ConfigureAwait(false);

        var viewModel = new CheckoutViewModel
        {
            CartItems = items,
            Addresses = addresses,
            PaymentMethods = payments,
        };

        return this.View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        return this.View();
    }
}
