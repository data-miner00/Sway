namespace Sway.Database.Seeder.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal interface IGenerator<T>
{
    Task<IEnumerable<T>> GenerateAsync(int count, CancellationToken cancellationToken);
}
