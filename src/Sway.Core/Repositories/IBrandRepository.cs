namespace Sway.Core.Repositories;

using Sway.Core.Models;

/// <summary>
/// The contract for <see cref="Brand"/> repository.
/// </summary>
public interface IBrandRepository
{
    /// <summary>
    /// Retrieves all brand.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of brands.</returns>
    Task<IEnumerable<Brand>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get brand by Id.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found brand.</returns>
    Task<Brand> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Create a new brand entry.
    /// </summary>
    /// <param name="brand">The brand to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(Brand brand, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing brand.
    /// </summary>
    /// <param name="brand">The brand to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Brand brand, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a brand by Id.
    /// </summary>
    /// <param name="id">The brand ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
