namespace Sway.Core.Models;

/// <summary>
/// The urgency of the notification.
/// </summary>
public enum NotificationPriority
{
    /// <summary>
    /// The default value.
    /// </summary>
    None,

    /// <summary>
    /// Not important.
    /// </summary>
    Low,

    /// <summary>
    /// Not so urgent.
    /// </summary>
    Normal,

    /// <summary>
    /// Urgent.
    /// </summary>
    High,
}
