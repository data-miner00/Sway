namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class CheckoutController : Controller
{
    private readonly IShoppingCartRepository cartRepository;
    private readonly IAddressRepository addressRepository;
    private readonly IPaymentMethodRepository paymentMethodRepository;
    private readonly IOrderRepository orderRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CheckoutController"/> class.
    /// </summary>
    /// <param name="cartRepository">The cart repository.</param>
    /// <param name="addressRepository">The address repository.</param>
    /// <param name="paymentMethodRepository">The payment repository.</param>
    /// <param name="orderRepository">The order repository.</param>
    public CheckoutController(
        IShoppingCartRepository cartRepository,
        IAddressRepository addressRepository,
        IPaymentMethodRepository paymentMethodRepository,
        IOrderRepository orderRepository)
    {
        this.cartRepository = Guard.ThrowIfNull(cartRepository);
        this.addressRepository = Guard.ThrowIfNull(addressRepository);
        this.paymentMethodRepository = Guard.ThrowIfNull(paymentMethodRepository);
        this.orderRepository = Guard.ThrowIfNull(orderRepository);
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
    public async Task<IActionResult> PlaceOrder(Guid addressId, Guid paymentId)
    {
        var userId = Constants.TestUserId;

        _ = Guid.TryParse(userId, out var guidUserId);

        var items = await this.cartRepository.GetCartItemsByUserIdAsync(userId, true, this.CancellationToken);

        var totalAmount = items.Select(x => x.UnitPrice * x.Quantity).Sum();

        var order = new Order
        {
            UserId = guidUserId,
            Status = OrderStatus.Pending,
            TotalAmount = totalAmount,
            Currency = "MYR",
        };

        var id = await this.orderRepository.CreateAsync(order, items, this.CancellationToken);
        await this.addressRepository.CopyForOrderAsync(addressId.ToString(), id.ToString(), default);
        await this.paymentMethodRepository.CopyForOrderPaymentMethodAsync(paymentId.ToString(), id.ToString(), default);

        // Todo: clean cart

        this.TempData[Constants.Success] = "Successfully placed order!";

        return this.RedirectToAction(nameof(OrderController.Details), "Order", new { Id = id });
    }
}
