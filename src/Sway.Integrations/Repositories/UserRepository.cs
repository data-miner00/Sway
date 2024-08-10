namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

using SpNames = Sway.Common.StoredProcedureNames;

/// <summary>
/// The repository for <see cref="User"/> resource.
/// </summary>
public sealed class UserRepository : IUserRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public UserRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    /// <inheritdoc/>
    public Task CreateAsync(User entity, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("Username", entity.Username);
        parameters.Add("FirstName", entity.FirstName);
        parameters.Add("LastName", entity.LastName);
        parameters.Add("DateOfBirth", entity.DateOfBirth);
        parameters.Add("Email", entity.Email);
        parameters.Add("Phone", entity.Phone);
        parameters.Add("PhotoUrl", entity.PhotoUrl);
        parameters.Add("Description", entity.Description);
        parameters.Add("PasswordHash", "default_hash");
        parameters.Add("PasswordSalt", "default_salt");
        parameters.Add("HashAlgorithm", "sha256");

        return this.connection.ExecuteAsync(
            SpNames.CreateNewUser,
            parameters,
            commandType: CommandType.StoredProcedure);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeleteUserById] @Id",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<User>> GetAllAsync(CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[Users];";

        return this.connection.QueryAsync<User>(query);
    }

    /// <inheritdoc/>
    public Task<User> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        var query = "SELECT * FROM [dbo].[vw_UserDetails] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<User>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(User entity, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_UpdateUser] @Id, @Username, @Status, @ProfileId, @CredentialId, @CartId, @Role, @DateOfBirth;",
            entity,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
