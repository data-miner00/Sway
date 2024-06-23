namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The abstraction for the <see cref="PaymentMethod"/> repository.
/// </summary>
public interface IPaymentMethodRepository
{
    /// <summary>
    /// Retrieves all the payment methods that has been set up by the user.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of payment methods.</returns>
    Task<IEnumerable<PaymentMethod>> GetAllByUserAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves a single payment method.
    /// </summary>
    /// <param name="id">The payment method Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The payment method.</returns>
    Task<PaymentMethod> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new payment method entry.
    /// </summary>
    /// <param name="paymentMethod">The payment method to be created.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task CreateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing payment method.
    /// </summary>
    /// <param name="paymentMethod">The payment method to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(PaymentMethod paymentMethod, CancellationToken cancellationToken);

    /// <summary>
    /// Deletes a payment method by Id.
    /// </summary>
    /// <param name="id">The payment method ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
