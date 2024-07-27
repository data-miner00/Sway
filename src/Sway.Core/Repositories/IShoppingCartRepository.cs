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

    Task<IEnumerable<CartItemDto>> GetCartItemsByUserIdAsync(string userId, CancellationToken cancellationToken);

    Task AddItemIntoCartForUserAsync(string userId, string productId, int quantity, CancellationToken cancellationToken);
}
