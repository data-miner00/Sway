namespace Sway.Core.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The generic repository abstraction for common CRUD operations.
/// </summary>
/// <typeparam name="T">The type of entity.</typeparam>
public interface IRepository<T>
{
    /// <summary>
    /// Retrieves all <typeparamref name="T"/>.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of <typeparamref name="T"/>.</returns>
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Gets <typeparamref name="T"/> by Id.
    /// </summary>
    /// <param name="id">The Id for <typeparamref name="T"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found <typeparamref name="T"/>.</returns>
    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new <typeparamref name="T"/> entry.
    /// </summary>
    /// <param name="entity">The <typeparamref name="T"/> to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The asynchronous task.</returns>
    Task CreateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing <typeparamref name="T"/> entity.
    /// </summary>
    /// <param name="entity">The updated and existing <typeparamref name="T"/>.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The asynchronous task.</returns>
    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes an existing <typeparamref name="T"/> entity.
    /// </summary>
    /// <param name="id">The Id of the <typeparamref name="T"/> to be removed.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The asynchronous task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
