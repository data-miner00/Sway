namespace Sway.Core.Models;

/// <summary>
/// The notification type.
/// </summary>
public enum NotificationType
{
    /// <summary>
    /// Default value.
    /// </summary>
    None,

    /// <summary>
    /// Pertaining to order updates.
    /// </summary>
    OrderUpdate,

    /// <summary>
    /// About a promotional activity.
    /// </summary>
    Promotion,

    /// <summary>
    /// Related to account updates.
    /// </summary>
    AccountUpdate,
}
