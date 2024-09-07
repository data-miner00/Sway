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

        var parameters = new DynamicParameters();
        parameters.Add("Street1", address.Street1);
        parameters.Add("Street2", address.Street2);
        parameters.Add("City", address.City);
        parameters.Add("State", address.State);
        parameters.Add("Postcode", address.Postcode);
        parameters.Add("Country", address.Country);
        parameters.Add("IsDefault", address.IsDefault);
        parameters.Add("Type", address.Type.ToString());
        parameters.Add("UserId", address.UserId.ToString());

        return this.connection.ExecuteAsync(
            SpNames.AddAddress,
            parameters,
            commandType: CommandType.StoredProcedure);
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

        var parameters = new DynamicParameters();
        parameters.Add("Id", address.Id.ToString());
        parameters.Add("Street1", address.Street1);
        parameters.Add("Street2", address.Street2);
        parameters.Add("City", address.City);
        parameters.Add("State", address.State);
        parameters.Add("Postcode", address.Postcode);
        parameters.Add("Country", address.Country);
        parameters.Add("IsDefault", address.IsDefault);
        parameters.Add("Type", address.Type.ToString());

        return this.connection.ExecuteAsync(
            SpNames.UpdateAddress,
            parameters,
            commandType: CommandType.StoredProcedure);
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
