namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

[Route("Profile/[controller]/[action]")]
public class PaymentMethodController : Controller
{
    private readonly IPaymentMethodRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public PaymentMethodController(IPaymentMethodRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var paymentMethods = await this.repository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(paymentMethods);
    }
}
