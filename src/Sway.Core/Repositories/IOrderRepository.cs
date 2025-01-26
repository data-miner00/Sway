namespace Sway.Core.Repositories;

using Sway.Core.Dtos;
using Sway.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

/// <summary>
/// The abstraction for <see cref="Order"/> repository.
/// </summary>
public interface IOrderRepository
{
    /// <summary>
    /// Retrieves all orders.
    /// </summary>
    /// <param name="userId">The user ID.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of orders.</returns>
    Task<IEnumerable<Order>> GetAllByUserIdAsync(string userId, CancellationToken cancellationToken);

    /// <summary>
    /// Retrieves the order information.
    /// </summary>
    /// <param name="id">The order Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found order.</returns>
    Task<Order> GetByIdAsync(string id, CancellationToken cancellationToken);

    /// <summary>
    /// Creates a new order.
    /// </summary>
    /// <param name="order">The order to be created.</param>
    /// <param name="cartItems">The cart items.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The created order id.</returns>
    Task<Guid> CreateAsync(Order order, IEnumerable<CartItemDto> cartItems, CancellationToken cancellationToken);

    /// <summary>
    /// Updates an existing order.
    /// </summary>
    /// <param name="order">The order to be updated.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The task.</returns>
    Task UpdateAsync(Order order, CancellationToken cancellationToken);

    /// <summary>
    /// Gets all human-friendly order lines of an order.
    /// </summary>
    /// <param name="orderId">The order Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The list of order lines.</returns>
    Task<IEnumerable<OrderLine>> GetOrderLinesAsync(string orderId, CancellationToken cancellationToken);

    /// <summary>
    /// Gets the order address associated.
    /// </summary>
    /// <param name="orderId">The order Id.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The order address found.</returns>
    Task<OrderAddress> GetOrderAddressAsync(string orderId, CancellationToken cancellationToken);

    Task<OrderPaymentMethod> GetOrderPaymentMethod(string orderId, CancellationToken cancellationToken);
}
