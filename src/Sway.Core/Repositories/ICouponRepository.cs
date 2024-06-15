﻿namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The contract for <see cref="Coupon"/> repository.
/// </summary>
public interface ICouponRepository
{
    /// <summary>
    /// Retrieves all coupons.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of coupons.</returns>
    Task<IEnumerable<Coupon>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get coupon by Id.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found coupon.</returns>
    Task<Coupon> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new coupon.
    /// </summary>
    /// <param name="coupon">The coupon to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(Coupon coupon, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing coupon.
    /// </summary>
    /// <param name="coupon">The coupon to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Coupon coupon, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a coupon by ID.
    /// </summary>
    /// <param name="id">The coupon ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
