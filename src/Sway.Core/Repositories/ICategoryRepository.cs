namespace Sway.Core.Repositories;

using Sway.Core.Models;

/// <summary>
/// The contract for <see cref="Category"/> repository.
/// </summary>
public interface ICategoryRepository
{
    /// <summary>
    /// Retrieves all categories.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of categories.</returns>
    Task<IEnumerable<Category>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get category by Id.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found category.</returns>
    Task<Category> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Created a new category entry.
    /// </summary>
    /// <param name="category">The category to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(Category category, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing category.
    /// </summary>
    /// <param name="category">The category to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Category category, CancellationToken cancellationToken);

    /// <summary>
    /// Deleted an category by Id.
    /// </summary>
    /// <param name="id">The category ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
