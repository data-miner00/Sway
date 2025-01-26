namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Dtos;
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
        this.connection = Guard.ThrowIfNull(connection);
    }

    /// <inheritdoc/>
    public async Task<Guid> CreateAsync(Order order, IEnumerable<CartItemDto> cartItems, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var dataTable = new DataTable();
        dataTable.Columns.Add("ProductId");
        dataTable.Columns.Add("Quantity");
        dataTable.Columns.Add("UnitPrice");
        dataTable.Columns.Add("TotalPrice");

        foreach (var cartItem in cartItems.Select(x => x.ToOrderLineDto()))
        {
            dataTable.Rows.Add(cartItem.ProductId, cartItem.Quantity, cartItem.UnitPrice, cartItem.TotalPrice);
        }

        var parameters = new DynamicParameters();
        parameters.Add("UserId", order.UserId);
        parameters.Add("Status", order.Status.ToString());
        parameters.Add("TotalAmount", order.TotalAmount);
        parameters.Add("Currency", order.Currency);
        parameters.Add("OrderLines", dataTable.AsTableValuedParameter("typ_OrderLines"));
        parameters.Add("Id", dbType: DbType.Guid, direction: ParameterDirection.Output, size: 5215585);

        var command = new CommandDefinition(
            SpNames.AddOrder,
            parameters,
            commandType: CommandType.StoredProcedure);

        await this.connection.ExecuteAsync(command);

        var id = parameters.Get<Guid>("Id");

        return id;
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

    /// <inheritdoc/>
    public Task<IEnumerable<OrderLine>> GetOrderLinesAsync(string orderId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.QueryAsync<OrderLine>(
            SpNames.GetOrderLinesByOrderId,
            new { OrderId = orderId },
            commandType: CommandType.StoredProcedure);
    }

    /// <inheritdoc/>
    public Task<OrderAddress> GetOrderAddressAsync(string orderId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var statement = "SELECT * FROM [dbo].[OrderAddresses] WHERE [OrderId] = @OrderId;";

        return this.connection.QueryFirstAsync<OrderAddress>(statement, new { OrderId = orderId });
    }

    /// <inheritdoc/>
    public Task<OrderPaymentMethod> GetOrderPaymentMethod(string orderId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var statement = "SELECT * FROM [dbo].[OrderPaymentMethods] WHERE [OrderId] = @OrderId;";

        return this.connection.QueryFirstAsync<OrderPaymentMethod>(statement, new { OrderId = orderId });
    }
}
