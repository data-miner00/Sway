namespace Sway.Core.Repositories;

using Sway.Core.Models;

/// <summary>
/// The contract for <see cref="Address"/> repository.
/// </summary>
public interface IAddressRepository : IRepository<Address>
{
    /// <summary>
    /// Gets all addresses that belongs to the user.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of addresses.</returns>
    Task<IEnumerable<Address>> GetAllByUserAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Copies the address to order address.
    /// </summary>
    /// <param name="addressId">The address Id.</param>
    /// <param name="orderId">The order Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CopyForOrderAsync(string addressId, string orderId, CancellationToken cancellationToken);
}
