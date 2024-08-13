namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductRatingRepository : IRepository<ProductRating>
{
    Task<IEnumerable<ProductRating>> GetAllForProductAsync(string productId, CancellationToken cancellationToken);
}
