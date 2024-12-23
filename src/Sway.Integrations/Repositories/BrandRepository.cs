namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository for <see cref="Brand"/>.
/// </summary>
public sealed class BrandRepository : IBrandRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="BrandRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public BrandRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(Brand brand, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddBrand] @Name, @Description, @LogoUrl;",
            brand,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeleteBrandById] @Id;",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = new CommandDefinition("SELECT * FROM [dbo].[Brands];");

        return this.connection.QueryAsync<Brand>(query);
    }

    /// <inheritdoc/>
    public Task<Brand> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = new CommandDefinition(
            "SELECT * FROM [dbo].[Brands] WHERE [Id] = @Id;",
            new { Id = id });

        return this.connection.QueryFirstAsync<Brand>(query);
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Brand brand, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateAddress] @Id, @Name, @Description, @LogoUrl;",
            brand);

        return this.connection.ExecuteAsync(command);
    }
}
