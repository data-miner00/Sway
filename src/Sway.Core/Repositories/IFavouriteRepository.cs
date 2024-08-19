namespace Sway.Core.Repositories;

using Sway.Core.Dtos;
using DeleteFavouriteRequest = Sway.Core.Dtos.CreateFavouriteRequest;

public interface IFavouriteRepository
{
    Task CreateAsync(CreateFavouriteRequest request, CancellationToken cancellationToken);

    Task DeleteAsync(DeleteFavouriteRequest request, CancellationToken cancellationToken);
}
