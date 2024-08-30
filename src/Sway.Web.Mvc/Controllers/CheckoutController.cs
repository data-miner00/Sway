namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public class CheckoutController : Controller
{
    private readonly IShoppingCartRepository cartRepository;
    private readonly IAddressRepository addressRepository;

    public CheckoutController(IShoppingCartRepository cartRepository, IAddressRepository addressRepository)
    {
        this.cartRepository = cartRepository;
        this.addressRepository = addressRepository;
    }

    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var items = await this.cartRepository.GetCartItemsByUserIdAsync(Constants.TestUserId, this.CancellationToken);
        var addresses = await this.addressRepository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);

        var viewModel = new CheckoutViewModel
        {
            CartItems = items,
            ShippingAddress = addresses.First(),
        };

        return this.View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> PlaceOrder()
    {
        return this.View();
    }
}
