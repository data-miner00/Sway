namespace Sway.Integrations.Repositories;

using Dapper;
using Sway.Common;
using Sway.Core.Models;
using Sway.Core.Repositories;
using System.Collections.Generic;
using System.Data;
using System.Threading;
using System.Threading.Tasks;

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
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_AddNewUser] @Name, @Status, @Role, @Email, @Phone, @PhotoUrl, @Description, @ShippingAddressId, @BillingAddressId, @DateOfBirth;",
            new
            {
                entity.Name,
                Status = entity.Status.ToString(),
                Role = entity.Role.ToString(),
                entity.Email,
                entity.Phone,
                entity.PhotoUrl,
                entity.Description,
                entity.ShippingAddressId,
                entity.BillingAddressId,
                entity.DateOfBirth,
            },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        var command = new CommandDefinition(
            "EXEC [dbo].[usp_DeleteUserById @Id",
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
        var query = "SELECT * FROM [dbo].[Users] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<User>(query);
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
