namespace Sway.Database.Seeder.Writers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface ISqlWriter<in T>
{
    Task BulkWriteAsync(IEnumerable<T> entities, CancellationToken cancellationToken);
}
