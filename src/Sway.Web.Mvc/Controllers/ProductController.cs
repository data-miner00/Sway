namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Dtos;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

public class ProductController : Controller
{
    public static readonly string ControllerName = "Product";

    private readonly IProductRepository productRepository;
    private readonly IProductRatingRepository ratingRepository;
    private readonly IFavouriteRepository favouriteRepository;

    private CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public ProductController(
        IProductRepository productRepository,
        IProductRatingRepository ratingRepository,
        IFavouriteRepository favouriteRepository)
    {
        this.productRepository = Guard.ThrowIfNull(productRepository);
        this.ratingRepository = Guard.ThrowIfNull(ratingRepository);
        this.favouriteRepository = Guard.ThrowIfNull(favouriteRepository);
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
        if (!Guid.TryParse(Constants.TestUserId, out var userId))
        {
            return this.BadRequest();
        }

        var request = new CreateFavouriteRequest
        {
            UserId = userId,
            ProductId = id,
        };

        await this.favouriteRepository.CreateAsync(request, this.CancellationToken);

        this.TempData[Constants.Success] = "Successfully added to favourites";

        return this.RedirectToAction(nameof(this.Details), new { id });
    }
}
