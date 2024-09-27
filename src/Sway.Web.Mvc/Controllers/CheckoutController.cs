namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public class CheckoutController : Controller
{
    private readonly IShoppingCartRepository cartRepository;
    private readonly IAddressRepository addressRepository;
    private readonly IPaymentMethodRepository paymentMethodRepository;

    public CheckoutController(
        IShoppingCartRepository cartRepository,
        IAddressRepository addressRepository,
        IPaymentMethodRepository paymentMethodRepository)
    {
        this.cartRepository = cartRepository;
        this.addressRepository = addressRepository;
        this.paymentMethodRepository = paymentMethodRepository;
    }

    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

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
            ShippingAddress = addresses.First(x => x.IsDefault),
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
