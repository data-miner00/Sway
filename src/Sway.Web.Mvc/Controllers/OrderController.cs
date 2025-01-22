namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;

public sealed class OrderController : Controller
{
    private readonly IOrderRepository repository;

    public OrderController(IOrderRepository repository)
    {
        this.repository = repository;
    }

    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var orders = await this.repository.GetAllByUserIdAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(orders);
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var order = await this.repository.GetByIdAsync(id.ToString(), this.CancellationToken);

        return this.View(order);
    }
}
