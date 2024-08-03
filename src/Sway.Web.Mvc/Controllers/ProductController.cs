namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

public class ProductController : Controller
{
    public static readonly string ControllerName = "Product";

    private readonly IProductRepository repository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ProductController(IProductRepository repository)
    {
        this.repository = repository;
    }

    public IActionResult Index()
    {
        return this.View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await this.repository.GetByIdAsync(id.ToString(), this.CancellationToken);

        return this.View(product);
    }
}
