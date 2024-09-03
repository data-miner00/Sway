namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

[Route("Profile/[controller]/[action]")]
public class AddressController : Controller
{
    private readonly IAddressRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public AddressController(IAddressRepository repository)
    {
        this.repository = repository;
    }

    public async Task<IActionResult> Index()
    {
        var addresses = await this.repository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);
        return this.View(addresses);
    }
}
