namespace Sway.Core.Repositories;

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
}
