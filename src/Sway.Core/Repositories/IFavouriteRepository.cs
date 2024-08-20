namespace Sway.Core.Repositories;

using Sway.Core.Dtos;
using Sway.Core.Models;
using DeleteFavouriteRequest = Sway.Core.Dtos.CreateFavouriteRequest;

public interface IFavouriteRepository
{
    Task<Favourite> GetAsync(string productId, string userId, CancellationToken cancellationToken);

    Task CreateAsync(CreateFavouriteRequest request, CancellationToken cancellationToken);

    Task DeleteAsync(DeleteFavouriteRequest request, CancellationToken cancellationToken);
}
