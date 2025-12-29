namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;

/// <summary>
/// The coupon controller.
/// </summary>
[Route("[controller]")]
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
    /// Gets the cancellation token.
    /// </summary>
    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    /// <summary>
    /// The coupon home page.
    /// </summary>
    /// <returns>The action result.</returns>
    public async Task<IActionResult> Index()
    {
        var coupons = await this.repository.GetByUserAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(coupons);
    }

    /// <summary>
    /// Deletes a coupon by Id.
    /// </summary>
    /// <param name="couponId">The coupon id.</param>
    /// <returns>The action result.</returns>
    [HttpDelete("{couponId}")]
    public async Task<IActionResult> Delete(string couponId)
    {
        await this.repository.DeleteByIdAsync(couponId, this.CancellationToken);

        return this.NoContent();
    }
}
