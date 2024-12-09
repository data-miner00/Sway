namespace Sway.Database.Seeder.Options;

/// <summary>
/// The configurations for SQL script sink.
/// </summary>
internal sealed class SqlSinkOption
{
    /// <summary>
    /// Gets or sets the output path for the SQL files generated.
    /// </summary>
    public string OutputPath { get; set; } = null!;

    /// <summary>
    /// Gets or sets the naming strategy of the files generated.
    /// </summary>
    public NamingStrategy NamingStrategy { get; set; }
}
