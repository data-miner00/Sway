namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Dtos;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using SpNames = Sway.Common.StoredProcedureNames;

public sealed class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly IDbConnection connection;

    public ShoppingCartRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    public Task<ShoppingCart> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        var query = "SELECT * FROM [dbo].[ShoppingCarts] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<ShoppingCart>(query, new { Id = id });
    }

    public Task<ShoppingCart?> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return this.connection.QuerySingleOrDefaultAsync<ShoppingCart>(
            SpNames.GetShoppingCartByUserId,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task<IEnumerable<CartItemDto>> GetCartItemsByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return this.connection.QueryAsync<CartItemDto>(
            SpNames.GetShoppingCartItemsByUserId,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task<IEnumerable<CartItem>> GetCartItemsInShoppingCartAsync(string cartId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[CartItems] WHERE [ShoppingCartId] = @CartId;";

        return this.connection.QueryAsync<CartItem>(query, new { CartId = cartId });
    }

    public Task AddItemIntoCartForUserAsync(string userId, string productId, int quantity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);
        parameters.Add("ProductId", productId);
        parameters.Add("Quantity", quantity);

        return this.connection.ExecuteAsync(
            SpNames.AddItemIntoCartForUser,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task IncrementCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.IncrementCartItemQuantity,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task DecrementCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.DecrementCartItemQuantity,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task SoftDeleteCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.SoftDeleteCartItem,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task UndoDeletedCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.UndoDeletedCartItem,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task SelectCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.SelectCartItem,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task DeselectCartItemAsync(string cartItemId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CartItemId", cartItemId);

        return this.connection.ExecuteAsync(
            SpNames.DeselectCartItem,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
