namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System;
using System.Data;
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
        this.connection = Guard.ThrowIfNull(connection);
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
            var hashedPassword = ConvertPasswordAndSaltToHash(credential.PasswordSalt, password);

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

    /// <inheritdoc/>
    public async Task<bool> ChangePasswordAsync(string userId, string oldPassword, string newPassword)
    {
        try
        {
            var credentialQuery = "SELECT * FROM [dbo].[vw_UserCredentials] WHERE [UserId] = @UserId;";
            var credential = await this.connection.QueryFirstAsync<UserCredential>(
                credentialQuery,
                new { UserId = userId });

            if (credential == null)
            {
                return false;
            }

            var hashedNewPassword = ConvertPasswordAndSaltToHash(credential.PasswordSalt, newPassword);
            var hashedOldPassword = ConvertPasswordAndSaltToHash(credential.PasswordSalt, oldPassword);

            var parameters = new DynamicParameters();
            parameters.Add("UserId", userId);
            parameters.Add("PurportedOldPasswordHash", hashedOldPassword);
            parameters.Add("NewPasswordHash", hashedNewPassword);

            var command = new CommandDefinition(
                SpNames.UpdateUserPassword,
                parameters,
                commandType: CommandType.StoredProcedure);

            await this.connection.ExecuteAsync(command).ConfigureAwait(false);

            return true;
        }
        catch (Exception ex)
        {
            await Console.Error.WriteLineAsync(ex.ToString());

            return false;
        }
    }

    private static string GenerateRandomString()
    {
        return RandomNumberGenerator.GetHexString(10 /* stub length */);
    }

    private static string ConvertPasswordAndSaltToHash(string salt, string password)
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
