namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Dtos;
using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class ProfileController : Controller
{
    private readonly IUserRepository userRepository;
    private readonly IAddressRepository addressRepository;
    private readonly ICredentialRepository credentialRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProfileController"/> class.
    /// </summary>
    /// <param name="userRepository">The user repository.</param>
    /// <param name="addressRepository">The address repository.</param>
    /// <param name="credentialRepository">The credential repository.</param>
    public ProfileController(
        IUserRepository userRepository,
        IAddressRepository addressRepository,
        ICredentialRepository credentialRepository)
    {
        this.userRepository = Guard.ThrowIfNull(userRepository);
        this.addressRepository = Guard.ThrowIfNull(addressRepository);
        this.credentialRepository = Guard.ThrowIfNull(credentialRepository);
    }

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    // GET: ProfileController
    public async Task<IActionResult> Index()
    {
        var user = await this.userRepository.GetByIdAsync(Constants.TestUserId, this.CancellationToken);
        var addresses = await this.addressRepository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);

        var model = new ProfileDetailsViewModel
        {
            User = user,
            BillingAddress = addresses.FirstOrDefault(x => x.Type.Equals(AddressType.Billing)),
            ShippingAddress = addresses.FirstOrDefault(x => x.Type.Equals(AddressType.Shipping)),
        };

        return this.View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Index(UpdateProfileRequest request)
    {
        var updatedProfile = new UserProfile
        {
            Id = request.UserId,
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Phone = request.Phone,
            PhotoUrl = request.PhotoUrl,
            Description = request.Description,
        };

        await this.userRepository.UpdateAsync(updatedProfile, this.CancellationToken);

        this.TempData[Constants.Success] = "Successfully updated profile.";

        return this.RedirectToAction(nameof(this.Index));
    }

    public IActionResult ChangePassword()
    {
        return this.View();
    }

    [HttpPost]
    public async Task<IActionResult> ChangePassword(ChangePasswordRequest request)
    {
        var isUpdateSuccess = await this.credentialRepository
            .ChangePasswordAsync(
                request.UserId.ToString(),
                request.OldPassword,
                request.NewPassword);

        if (isUpdateSuccess)
        {
            this.TempData[Constants.Success] = "Password updated successfully";
        }
        else
        {
            this.TempData[Constants.Error] = "Password update failed.";
        }

        return this.View();
    }
}
