namespace Sway.Database.Seeder;

/// <summary>
/// The naming strategy for naming a file.
/// </summary>
internal enum NamingStrategy
{
    /// <summary>
    /// The default value.
    /// </summary>
    None,

    /// <summary>
    /// Name by random <see cref="Guid"/>.
    /// </summary>
    Guid,

    /// <summary>
    /// Name by current timestamp.
    /// </summary>
    Timestamp,
}
