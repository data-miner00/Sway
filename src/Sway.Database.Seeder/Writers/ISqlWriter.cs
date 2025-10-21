namespace Sway.Database.Seeder.Writers;

using System.Collections.Generic;
using System.Threading.Tasks;

internal interface ISqlWriter<in T>
{
    Task BulkWriteAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
}
