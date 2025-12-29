namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;
using System.Diagnostics;

/// <summary>
/// The home controller.
/// </summary>
public sealed class HomeController : Controller
{
    private readonly IProductRepository productRepository;

    /// <summary>
    /// Initializes a new instance of the <see cref="HomeController"/> class.
    /// </summary>
    /// <param name="productRepository">The product repository.</param>
    public HomeController(IProductRepository productRepository)
    {
        this.productRepository = Guard.ThrowIfNull(productRepository);
    }

    public async Task<IActionResult> Index()
    {
        var products = await this.productRepository.GetAllAsync(default);

        return this.View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
