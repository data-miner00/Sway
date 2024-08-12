namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
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

public sealed class ProductRatingRepository : IProductRatingRepository
{
    private readonly IDbConnection connection;

    public ProductRatingRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    public Task CreateAsync(ProductRating productRating, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productRating.ProductId);
        parameters.Add("AuthorId", productRating.AuthorId);
        parameters.Add("Rating", productRating.Rating);
        parameters.Add("Comment", productRating.Comment);

        return this.connection.ExecuteAsync(
            SpNames.AddProductRating,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("Id", id);

        return this.connection.ExecuteAsync(
            SpNames.DeleteProductRatingById,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task<IEnumerable<ProductRating>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[ProductRatings];";

        return this.connection.QueryAsync<ProductRating>(query);
    }

    public Task<IEnumerable<ProductRating>> GetAllForProduct(string productId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("ProductId", productId);

        return this.connection.QueryAsync<ProductRating>(
            SpNames.GetRatingsForProduct,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    public Task<ProductRating> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[ProductRatings] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<ProductRating>(query, new { Id = id });
    }

    public Task UpdateAsync(ProductRating productRating, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("Id", productRating.Id);
        parameters.Add("Rating", productRating.Rating);
        parameters.Add("Comment", productRating.Comment);

        return this.connection.ExecuteAsync(
            SpNames.UpdateProductRatingById,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
