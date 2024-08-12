namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRatingRepository
{
    Task<IEnumerable<ProductRating>> GetAllAsync(CancellationToken cancellationToken);

    Task<IEnumerable<ProductRating>> GetAllForProduct(string productId, CancellationToken cancellationToken);

    Task<ProductRating> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task CreateAsync(ProductRating productRating, CancellationToken cancellationToken);

    Task UpdateAsync(ProductRating productRating, CancellationToken cancellationToken);

    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
