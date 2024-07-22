namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

public class ProfileController : Controller
{
    private readonly IUserRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ProfileController(IUserRepository repository)
    {
        this.repository = repository;
    }

    // GET: ProfileController
    public async Task<IActionResult> Index()
    {
        var user = await this.repository.GetByIdAsync("2BA7AD7C-4731-43BF-AE9C-28B0BD2B0095", this.CancellationToken);

        return this.View(user);
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
