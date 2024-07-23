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
        var query = "SELECT * FROM [dbo].[ShoppingCarts] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<ShoppingCart>(query, new { Id = id });
    }

    public Task<ShoppingCart?> GetByUserIdAsync(string userId, CancellationToken cancellationToken)
    {
        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return this.connection.QuerySingleOrDefaultAsync<ShoppingCart>(
            SpNames.GetShoppingCartByUserId,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task<IEnumerable<CartItem>> GetCartItemsInShoppingCartAsync(string cartId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[CartItems] WHERE [ShoppingCartId] = @CartId;";

        return this.connection.QueryAsync<CartItem>(query, new { CartId = cartId });
    }
}
