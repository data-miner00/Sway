namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// The credential repository.
/// </summary>
public sealed class CredentialRepository : ICredentialRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="CredentialRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public CredentialRepository(IDbConnection connection)
    {
        this.connection = connection;
    }

    /// <inheritdoc/>
    public async Task<UserCredential?> GetByUsernameAsync(string username)
    {
        try
        {
            var query = "SELECT * FROM [dbo].[vw_UserCredentials] WHERE [Username] = @Username;";
            var credential = await this.connection
                .QueryFirstAsync<UserCredential>(query, new { Username = username })
                .ConfigureAwait(false);

            return credential;
        }
        catch (InvalidOperationException)
        {
            return null;
        }
    }

    /// <inheritdoc/>
    public async Task<bool> ChangePasswordAsync(string username, string password)
    {
        try
        {
            var credential = await this.GetByUsernameAsync(username).ConfigureAwait(false);

            if (credential is null)
            {
                return false;
            }

            var command = "EXEC [dbo].[usp_UpdateUserPassword] @Username, @PasswordHash;";
            var hashedPassword = this.ConvertPasswordAndSaltToHash(credential.PasswordSalt, password);

            await this.connection
                .ExecuteAsync(command, new { Username = username, Password = hashedPassword })
                .ConfigureAwait(false);

            return true;
        }
        catch
        {
            return false;
        }
    }

    private string GenerateRandomString()
    {
        return RandomNumberGenerator.GetHexString(10 /* stub length */);
    }

    private string ConvertPasswordAndSaltToHash(string salt, string password)
    {
        var sb = new StringBuilder();
        var mixture = salt + password;
        var encodedMixture = Encoding.UTF8.GetBytes(mixture);
        var hashedBytes = SHA1.HashData(encodedMixture);

        foreach (var bytes in hashedBytes)
        {
            sb.Append(bytes.ToString("x2"));
        }

        return sb.ToString();
    }
}
