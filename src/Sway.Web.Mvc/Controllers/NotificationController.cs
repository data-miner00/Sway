﻿namespace Sway.Web.Mvc.Controllers;

using Microsoft.AspNetCore.Mvc;
using Sway.Common;
using Sway.Core.Repositories;

public sealed class NotificationController : Controller
{
    private readonly INotificationRepository repository;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationController"/> class.
    /// </summary>
    /// <param name="repository">The notification repository.</param>
    public NotificationController(INotificationRepository repository)
    {
        this.repository = Guard.ThrowIfNull(repository);
    }

    public CancellationToken CancellationToken => this.HttpContext.RequestAborted;

    public async Task<IActionResult> Index()
    {
        var notifications = await this.repository.GetAllByUserIdAsync(Constants.TestUserId, this.CancellationToken);

        return this.View(notifications);
    }

    [HttpPost("[controller]/[action]/{notificationId}")]
    public async Task Read(int notificationId)
    {
        try
        {
            await this.repository.MarkAsReadAsync(notificationId, this.CancellationToken);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex);
        }
    }
}
