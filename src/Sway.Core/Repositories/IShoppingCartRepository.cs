namespace Sway.Core.Repositories;

using Sway.Core.Dtos;
using Sway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IShoppingCartRepository
{
    Task<ShoppingCart> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task<ShoppingCart?> GetByUserIdAsync(string userId, CancellationToken cancellationToken);

    Task<IEnumerable<CartItem>> GetCartItemsInShoppingCartAsync(string cartId, CancellationToken cancellationToken);

    Task<IEnumerable<CartItemDto>> GetCartItemsByUserIdAsync(string userId, bool selectedOnly, CancellationToken cancellationToken);

    Task AddItemIntoCartForUserAsync(string userId, string productId, int quantity, CancellationToken cancellationToken);

    Task IncrementCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task DecrementCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task SoftDeleteCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task UndoDeletedCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task SelectCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task DeselectCartItemAsync(string cartItemId, CancellationToken cancellationToken);

    Task ClearSelectedCartItems(string userId, CancellationToken cancellationToken);
}
