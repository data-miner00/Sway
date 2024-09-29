namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Threading.Tasks;

/// <summary>
/// Interface for credential repository.
/// </summary>
public interface ICredentialRepository
{
    /// <summary>
    /// Gets credential info by username.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <returns>The found credential info.</returns>
    public Task<UserCredential?> GetByUsernameAsync(string username);

    /// <summary>
    /// Updates the password of a user.
    /// </summary>
    /// <param name="username">The username.</param>
    /// <param name="password">The new password.</param>
    /// <returns>A flag indicating whether the password changed successfully.</returns>
    public Task<bool> ChangePasswordAsync(string username, string password);

    /// <summary>
    /// Updates the user password by user Id.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="oldPassword">The old password.</param>
    /// <param name="newPassword">The new password.</param>
    /// <returns>A flag indicating whether the password changed successfully.</returns>
    public Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword);
}
