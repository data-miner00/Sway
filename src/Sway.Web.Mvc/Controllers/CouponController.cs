namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;

/// <summary>
/// The coupon controller.
/// </summary>
public class CouponController : Controller
{
    private readonly ICouponRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="CouponController"/> class.
    /// </summary>
    /// <param name="repository">The coupon repository.</param>
    public CouponController(ICouponRepository repository)
    {
        this.repository = Guard.ThrowIfNull(repository);
    }

    /// <summary>
    /// The coupon home page.
    /// </summary>
    /// <returns>The action result.</returns>
    public async Task<IActionResult> Index()
    {
        var coupons = await this.repository.GetByUserAsync(Constants.TestUserId, default);

        return this.View(coupons);
    }
}
