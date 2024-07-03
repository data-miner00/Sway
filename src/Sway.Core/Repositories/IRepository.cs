namespace Sway.Core.Repositories;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAllAsync(CancellationToken cancellationToken);

    Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);

    Task CreateAsync(T entity, CancellationToken cancellationToken);

    Task UpdateAsync(T entity, CancellationToken cancellationToken);

    Task DeleteByIdAsync(string id, CancellationToken cancellationToken);
}
