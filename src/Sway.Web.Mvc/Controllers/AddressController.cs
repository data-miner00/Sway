namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Core.Dtos;
using Sway.Core.Models;

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

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAddressRequest request)
    {
        var address = new Address
        {
            UserId = Constants.TestUserId,
            Street1 = request.Street1,
            Street2 = request.Street2,
            City = request.City,
            Postcode = request.Postcode,
            State = request.State,
            Country = request.Country,
            IsDefault = request.IsDefault,
            Type = AddressType.Shipping,
        };

        await this.repository.CreateAsync(address, this.CancellationToken);

        return this.Ok();
    }
}
