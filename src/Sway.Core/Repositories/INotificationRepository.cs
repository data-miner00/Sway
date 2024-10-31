namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The abstraction for notification repository.
/// </summary>
public interface INotificationRepository
{
    /// <summary>
    /// Retrieves all notifications by a user.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of notifications.</returns>
    Task<IEnumerable<Notification>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Marks the notification as read.
    /// </summary>
    /// <param name="notificationId">The notification Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task MarkAsReadAsync(int notificationId, CancellationToken cancellationToken);
}
