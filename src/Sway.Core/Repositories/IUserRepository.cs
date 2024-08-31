namespace Sway.Core.Repositories;

using Sway.Core.Models;

/// <summary>
/// The repository abstraction for <see cref="User"/>.
/// </summary>
public interface IUserRepository : IRepository<User>
{
    /// <summary>
    /// Updates the user profile only.
    /// </summary>
    /// <param name="profile">The profile to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(UserProfile profile, CancellationToken cancellationToken);
}
