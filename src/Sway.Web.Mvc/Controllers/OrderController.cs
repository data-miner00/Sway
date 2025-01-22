namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Core.Repositories;
using Sway.Web.Mvc.Models;

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
        var orderLines = await this.repository.GetOrderLinesAsync(id.ToString(), this.CancellationToken);

        var viewModel = new OrderDetailsViewModel
        {
            Order = order,
            OrderLines = orderLines,
        };

        return this.View(viewModel);
    }
}
