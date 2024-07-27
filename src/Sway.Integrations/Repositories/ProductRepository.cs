namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository layer for product.
/// </summary>
public sealed class ProductRepository : IProductRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public ProductRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddProduct] @Name, @Description, @Price, @InStock, @SKU, @BrandId, @CategoryId;",
            product,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeleteProductById] @Id;",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition("SELECT * FROM [dbo].[Products];");

        return this.connection.QueryAsync<Product>(command);
    }

    /// <inheritdoc/>
    public Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
                "SELECT * FROM Products WHERE Id = @Id;",
                new { Id = id });

        return this.connection.QueryFirstAsync<Product>(command);
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Product product, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateProduct] @Id, @Name, @Description, @Price, @InStock, @SKU, @BrandId, @CategoryId;",
            product,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
