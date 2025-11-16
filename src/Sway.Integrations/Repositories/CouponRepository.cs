namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The coupon repository implementation.
/// </summary>
public sealed class CouponRepository : ICouponRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CouponRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public CouponRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public Task CreateAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", coupon.OwnerId);
        parameters.Add("Code", coupon.Code);
        parameters.Add("Description", coupon.Description);
        parameters.Add("DiscountAmount", coupon.DiscountAmount);
        parameters.Add("DiscountUnit", coupon.DiscountUnit);
        parameters.Add("ApplicableForBrand", coupon.ApplicableForBrand);

        return this.connection.ExecuteAsync(
            SpNames.AddCouponForUser,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("CouponId", id);

        return this.connection.ExecuteAsync(
            SpNames.DeleteCouponById,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Coupon>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return this.connection.QueryAsync<Coupon>("SELECT * FROM [dbo].[Coupons];");
    }

    /// <inheritdoc/>
    public Task<Coupon> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[Coupons] WHERE [Id] = @Id";

        return this.connection.QueryFirstAsync<Coupon>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Coupon coupon, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateCoupon] @Id, @OwnerId, @Code, @Description, @DiscountAmount, @DiscountUnit, @ApplicableForBrand, @AppliedToOrder, @ExpireAt;",
            coupon,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Coupon>> GetByUserAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return this.connection.QueryAsync<Coupon>(
            SpNames.GetCouponsForUser,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
