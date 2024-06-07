namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository for <see cref="Category"/>.
/// </summary>
public sealed class CategoryRepository : ICategoryRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CategoryRepository"/> class.
    /// </summary>
    /// <param name="connection">The db connection.</param>
    public CategoryRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(Category category, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddCategory] @Name, @Description, @ParentId;",
            category,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeleteCategoryById] @Id;",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[Categories];";

        return this.connection.QueryAsync<Category>(query);
    }

    /// <inheritdoc/>
    public Task<Category> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[Categories] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<Category>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Category category, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateCategory] @Id, @Name, @Description, @ParentId;",
            category,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
