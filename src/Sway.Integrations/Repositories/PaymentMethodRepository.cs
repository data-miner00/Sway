namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository layer for <see cref="PaymentMethod"/>.
/// </summary>
public sealed class PaymentMethodRepository : IPaymentMethodRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentMethodRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public PaymentMethodRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddPaymentMethod] @UserId, @Type, @Provider, @AccountNo, @ExpiryDate;",
            paymentMethod,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeletePaymentMethodById] @Id;",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<PaymentMethod>> GetAllByUserAsync(string userId, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[PaymentMethods] WHERE [UserId] = @UserId;";

        return this.connection.QueryAsync<PaymentMethod>(query, new { UserId = userId });
    }

    /// <inheritdoc/>
    public Task<PaymentMethod> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[PaymentMethods] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<PaymentMethod>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdatePaymentMethod] @Id, @UserId, @Type, @Provider, @AccountNo, @ExpiryDate;",
            paymentMethod,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
