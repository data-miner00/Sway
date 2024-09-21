namespace Sway.Database.Seeder.Options;

/// <summary>
/// The configurations for database.
/// </summary>
internal sealed class DatabaseOption
{
    /// <summary>
    /// Gets or sets the connection string of the database.
    /// </summary>
    public string ConnectionString { get; set; } = null!;
}
