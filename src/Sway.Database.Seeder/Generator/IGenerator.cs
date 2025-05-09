namespace Sway.Database.Seeder.Generator;

using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The interface for entity generator.
/// </summary>
/// <typeparam name="T">The entity to be generated.</typeparam>
internal interface IGenerator<T>
{
    /// <summary>
    /// Generate a list of <typeparamref name="T"/>.
    /// </summary>
    /// <param name="count">Amount of entities to be generated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of generated entities.</returns>
    Task<IEnumerable<T>> GenerateAsync(int count, CancellationToken cancellationToken);
}
