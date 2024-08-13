namespace Sway.Database.Seeder.Options;

internal sealed class SqlSinkOption
{
    public string OutputPath { get; set; }

    public NamingStrategy NamingStrategy { get; set; }
}
