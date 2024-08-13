namespace Sway.Database.Seeder;

using Sway.Common;
using System;

internal sealed class SqlFileNameBuilder
{
    private const string SqlFileExtension = ".sql";
    private readonly string basePath;
    private readonly NamingStrategy namingStrategy;

    public SqlFileNameBuilder(string basePath, NamingStrategy namingStrategy)
    {
        this.basePath = Guard.ThrowIfNullOrWhitespace(basePath);
        this.namingStrategy = Guard.ThrowIfDefault(namingStrategy);
    }

    // TODO: Prefixable file name
    public string Prefix { get; } = string.Empty;

    public string Build()
    {
        var fileName = this.namingStrategy switch
        {
            NamingStrategy.Timestamp => string.Concat(DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss"), SqlFileExtension),
            _ => throw new InvalidOperationException("The naming strategy are not supported."),
        };

        return Path.Join(this.basePath, fileName);
    }
}
