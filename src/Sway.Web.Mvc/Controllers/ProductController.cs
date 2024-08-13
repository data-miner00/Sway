namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public class ProductController : Controller
{
    public static readonly string ControllerName = "Product";

    private readonly IProductRepository productRepository;
    private readonly IProductRatingRepository ratingRepository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ProductController(IProductRepository productRepository, IProductRatingRepository ratingRepository)
    {
        this.productRepository = Guard.ThrowIfNull(productRepository);
        this.ratingRepository = Guard.ThrowIfNull(ratingRepository);
    }

    public IActionResult Index()
    {
        return this.View();
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var product = await this.productRepository.GetByIdAsync(id.ToString(), this.CancellationToken);
        var ratings = await this.ratingRepository.GetAllForProductAsync(id.ToString(), this.CancellationToken);

        var viewModel = new ProductDetailsViewModel
        {
            Product = product,
            Ratings = ratings,
        };

        return this.View(viewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Favourite(Guid id)
    {
        return this.View();
    }
}
