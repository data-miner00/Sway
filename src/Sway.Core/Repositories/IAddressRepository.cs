namespace Sway.Core.Repositories;

using Sway.Core.Models;

/// <summary>
/// The contract for <see cref="Address"/> repository.
/// </summary>
public interface IAddressRepository
{
    /// <summary>
    /// Retrieves all addresses.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of addresses.</returns>
    Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get address by Id.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found address.</returns>
    Task<Address> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new address entry.
    /// </summary>
    /// <param name="address">The address to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(Address address, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing address.
    /// </summary>
    /// <param name="address">The address to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Address address, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes an address by Id.
    /// </summary>
    /// <param name="id">The address ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
