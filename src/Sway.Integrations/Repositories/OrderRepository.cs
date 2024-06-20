namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The repository layer for <see cref="Order"/>.
/// </summary>
public sealed class OrderRepository : IOrderRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="OrderRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public OrderRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(Order order, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddOrder] @UserId, @Status, @TotalAmount, @Currency, @PaymentInfoId, @ShippingAddressId, @BillingAddressId;",
            order,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Order>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.QueryAsync<Order>(
            "SELECT * FROM [dbo].[Orders] WHERE [UserId] = @UserId;",
            new { UserId = userId });
    }

    /// <inheritdoc/>
    public Task<Order> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[Orders] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<Order>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Order order, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateOrder] @Id, @UserId, @Status, @TotalAmount, @Currency, @PaymentInfoId, @ShippingAddressId, @BillingAddressId;",
            order,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
