namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository layer for notification.
/// </summary>
public sealed class NotificationRepository : INotificationRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationRepository"/> class.
    /// </summary>
    /// <param name="connection">The db connection.</param>
    public NotificationRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Notification>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.QueryAsync<Notification>(
            SpNames.GetNotificationsByUserId,
            new { UserId = userId },
            commandType: CommandType.StoredProcedure);
    }

    /// <inheritdoc/>
    public Task MarkAsReadAsync(int notificationId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.ExecuteAsync(
            SpNames.MarkNotificationAsRead,
            new { Id = notificationId },
            commandType: CommandType.StoredProcedure);
    }
}
