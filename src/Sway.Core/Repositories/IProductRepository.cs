namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The contract for <see cref="Product"/> repository.
/// </summary>
public interface IProductRepository
{
    /// <summary>
    /// Retrieves all products.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of products.</returns>
    Task<IEnumerable<Product>> GetAllAsync(CancellationToken cancellationToken);

    /// <summary>
    /// Get product by Id.
    /// </summary>
    /// <param name="id">The ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found product.</returns>
    Task<Product> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new product entry.
    /// </summary>
    /// <param name="product">The product to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing product.
    /// </summary>
    /// <param name="product">The product to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Product product, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a product by ID.
    /// </summary>
    /// <param name="id">The product ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Searches for products based on a query string.
    /// </summary>
    /// <param name="query">The query string.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of matched products.</returns>
    Task<IEnumerable<Product>> SearchAsync(string query, CancellationToken cancellationToken);
}
