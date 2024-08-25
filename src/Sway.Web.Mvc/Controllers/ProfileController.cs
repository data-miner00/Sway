namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public sealed class ProfileController : Controller
{
    private readonly IUserRepository userRepository;
    private readonly IAddressRepository addressRepository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ProfileController(IUserRepository userRepository, IAddressRepository addressRepository)
    {
        this.userRepository = userRepository;
        this.addressRepository = addressRepository;
    }

    // GET: ProfileController
    public async Task<IActionResult> Index()
    {
        var user = await this.userRepository.GetByIdAsync(Constants.TestUserId, this.CancellationToken);
        var addresses = await this.addressRepository.GetAllByUserAsync(Constants.TestUserId, this.CancellationToken);

        var model = new ProfileDetailsViewModel
        {
            User = user,
            BillingAddress = addresses.FirstOrDefault(x => x.Type.ToString().Equals("Billing", StringComparison.InvariantCulture)),
            ShippingAddress = addresses.FirstOrDefault(x => x.Type.ToString().Equals("Shipping", StringComparison.InvariantCulture)),
        };

        return this.View(model);
    }

    // GET: ProfileController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: ProfileController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ProfileController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProfileController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: ProfileController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: ProfileController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: ProfileController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
