namespace Sway.Core.Repositories;

using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The abstraction for the <see cref="PaymentMethod"/> repository.
/// </summary>
public interface IPaymentMethodRepository : IRepository<PaymentMethod>
{
    /// <summary>
    /// Retrieves all the payment methods that has been set up by the user.
    /// </summary>
    /// <param name="userId">The user Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of payment methods.</returns>
    Task<IEnumerable<PaymentMethod>> GetAllByUserAsync(string userId, CancellationToken cancellationToken);
}
