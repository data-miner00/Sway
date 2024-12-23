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
/// The repository layer for <see cref="PaymentMethod"/>.
/// </summary>
public sealed class PaymentMethodRepository : IPaymentMethodRepository
{
    private readonly IDbConnection connection;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentMethodRepository"/> class.
    /// </summary>
    /// <param name="connection">The database connection.</param>
    public PaymentMethodRepository(IDbConnection connection)
    {
        this.connection = Guard.ThrowIfNull(connection);
    }

    /// <inheritdoc/>
    public Task CreateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("UserId", paymentMethod.UserId);
        parameters.Add("Type", paymentMethod.Type.ToString());
        parameters.Add("Provider", paymentMethod.Provider);
        parameters.Add("CVV", paymentMethod.CVV);
        parameters.Add("ExpiryDate", paymentMethod.ExpiryDate);
        parameters.Add("CardholderName", paymentMethod.CardholderName);
        parameters.Add("CardNumber", paymentMethod.CardNumber);
        parameters.Add("WalletAddress", paymentMethod.WalletAddress);
        parameters.Add("CardIssuingCountry", paymentMethod.CardIssuingCountry);
        parameters.Add("CardIssuingBank", paymentMethod.CardIssuingBank);
        parameters.Add("Currency", paymentMethod.Currency);
        parameters.Add("Balance", paymentMethod.Balance);
        parameters.Add("IsDefault", paymentMethod.IsDefault);

        var command = new CommandDefinition(
            SpNames.AddPaymentMethod,
            parameters,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    /// <inheritdoc/>
    public Task DeleteByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var command = new CommandDefinition(
            SpNames.DeletePaymentMethodById,
            new { Id = id },
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }

    public Task<IEnumerable<PaymentMethod>> GetAllAsync(CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<PaymentMethod>> GetAllByUserAsync(string userId, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[PaymentMethods] WHERE [UserId] = @UserId;";

        return this.connection.QueryAsync<PaymentMethod>(query, new { UserId = userId });
    }

    /// <inheritdoc/>
    public Task<PaymentMethod> GetByIdAsync(string id, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var query = "SELECT * FROM [dbo].[PaymentMethods] WHERE [Id] = @Id;";

        return this.connection.QueryFirstAsync<PaymentMethod>(query, new { Id = id });
    }

    /// <inheritdoc/>
    public Task UpdateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var parameters = new DynamicParameters();
        parameters.Add("Id", paymentMethod.Id);
        parameters.Add("Type", paymentMethod.Type.ToString());
        parameters.Add("Provider", paymentMethod.Provider);
        parameters.Add("CVV", paymentMethod.CVV);
        parameters.Add("ExpiryDate", paymentMethod.ExpiryDate);
        parameters.Add("CardholderName", paymentMethod.CardholderName);
        parameters.Add("CardNumber", paymentMethod.CardNumber);
        parameters.Add("WalletAddress", paymentMethod.WalletAddress);
        parameters.Add("CardIssuingCountry", paymentMethod.CardIssuingCountry);
        parameters.Add("CardIssuingBank", paymentMethod.CardIssuingBank);
        parameters.Add("Currency", paymentMethod.Currency);
        parameters.Add("Balance", paymentMethod.Balance);
        parameters.Add("IsDefault", paymentMethod.IsDefault);

        var command = new CommandDefinition(
            SpNames.UpdatePaymentMethod,
            parameters,
            commandType: CommandType.StoredProcedure);

        return this.connection.ExecuteAsync(command);
    }
}
