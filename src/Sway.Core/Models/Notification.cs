namespace Sway.Core.Models;

using System;

/// <summary>
/// The notification for user.
/// </summary>
public class Notification
{
    /// <summary>
    /// Gets or sets the id.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Gets or sets the targeted user Id.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the type of the notification.
    /// </summary>
    public NotificationType Type { get; set; }

    /// <summary>
    /// Gets or sets the message.
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    /// Gets or sets the url associated with the notification.
    /// </summary>
    public string? Url { get; set; }

    /// <summary>
    /// Gets or sets the urgency for the notification.
    /// </summary>
    public NotificationPriority Priority { get; set; }

    /// <summary>
    /// Gets or sets the optional icon.
    /// </summary>
    public string? Icon { get; set; }

    /// <summary>
    /// Gets or sets the Id of an entity that is related to this notification.
    /// </summary>
    public string? RelatedId { get; set; }

    /// <summary>
    /// Gets or sets the date of creation.
    /// </summary>
    public DateTime CreatedAt { get; set; }

    /// <summary>
    /// Gets or sets the date when the notification was read.
    /// </summary>
    public DateTime? ReadAt { get; set; }
}
