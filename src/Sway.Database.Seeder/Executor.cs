namespace Sway.Database.Seeder;

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal sealed class Executor : IExecutor
{
    private readonly IDbConnection connection;

    public Executor(IDbConnection connection)
    {
        this.connection = connection;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        return Console.Out.WriteLineAsync(this.connection.Database);
    }
}
