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
/// The repository for <see cref="Address"/>.
/// </summary>
public sealed class AddressRepository : IAddressRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="AddressRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public AddressRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    /// <inheritdoc/>
    public Task CreateAsync(Address address, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC usp_AddAddress @Type, @Street1, @Street2, @City, @State, @Postcode, @Country;",
            address,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC usp_DeleteAddressById @Id",
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Address>> GetAllAsync(CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "SELECT * FROM Addresses;");

        return this.connection.QueryAsync<Address>(command);
    }

    /// <inheritdoc/>
    public Task<Address> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "SELECT * FROM Addresses WHERE Id = @Id;",
            new { Id = id });

        return this.connection.QueryFirstAsync<Address>(command);
    }

    /// <inheritdoc/>
    public Task UpdateAsync(Address address, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            "EXEC usp_UpdateAddress @Id, @Type, @Street1, @Street2, @City, @State, @Postcode, @Country;",
            address);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Address>> GetAllByUserAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", userId);

        return this.connection.QueryAsync<Address>(
            SpNames.GetAddressesByUserId,
            parameters,
            commandType: CommandType.StoredProcedure);
    }
}
