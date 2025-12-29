namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Core.Dtos;
using Sway.Core.Models;
using Sway.Common;

/// <summary>
/// The address controller.
/// </summary>
[Route("Profile/[controller]/[action]")]
public sealed class AddressController : Controller
{
    private readonly IAddressRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressController"/> class.
    /// </summary>
    /// <param name="repository">The address repository.</param>
    public AddressController(IAddressRepository repository)
    {
        this.repository = Guard.ThrowIfNull(repository);
    }

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var addresses = await this.repository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);
        return this.View(addresses);
    }

    [Route("{id:guid}")]
    public async Task<IActionResult> Index(Guid id)
    {
        var address = await this.repository.GetByIdAsync(id.ToString(), this.CancellationToken);

        return this.Ok(address);
    }

    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateAddressRequest request)
    {
        if (!Guid.TryParse(request.Id, out var id))
        {
            return this.BadRequest("The Id is not a Guid.");
        }

        var address = new Address
        {
            Id = id,
            Street1 = request.Street1,
            Street2 = request.Street2,
            City = request.City,
            Postcode = request.Postcode,
            State = request.State,
            Country = request.Country,
            IsDefault = request.IsDefault,
            Type = AddressType.Shipping,
        };

        await this.repository.UpdateAsync(address, this.CancellationToken);

        return this.Ok();
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateAddressRequest request)
    {
        if (!Guid.TryParse(Constants.TestUserId, out var userId))
        {
            return this.BadRequest("The TestUserId is not a Guid.");
        }

        var address = new Address
        {
            UserId = userId,
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

        return this.Redirect(string.Empty);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await this.repository.DeleteByIdAsync(id.ToString(), this.CancellationToken);
        return this.NoContent();
    }
}
