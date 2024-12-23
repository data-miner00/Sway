namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Dtos;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using DeleteFavouriteRequest = Sway.Core.Dtos.CreateFavouriteRequest;

public sealed class FavouriteRepository : IFavouriteRepository
{
    private readonly IDbConnection connection;

    public FavouriteRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    public Task<Favourite> GetAsync(string productId, string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productId);
        parameters.Add("UserId", userId);

        var query = "SELECT * FROM [dbo].[Favourites] WHERE [ProductId] = @ProductId AND [UserId] = @UserId;";

        return this.connection.QueryFirstAsync<Favourite>(query, parameters);
    }

    public Task CreateAsync(CreateFavouriteRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.ExecuteAsync(
            SpNames.AddFavourite,
            request,
            commandType: CommandType.StoredProcedure);
    }

    public Task DeleteAsync(DeleteFavouriteRequest request, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.ExecuteAsync(
            SpNames.DeleteFavourite,
            request,
            commandType: CommandType.StoredProcedure);
    }
}
