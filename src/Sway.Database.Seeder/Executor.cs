namespace Sway.Database.Seeder;

using Sway.Database.Seeder.Sinks;
using System.Threading.Tasks;

internal sealed class Executor : IExecutor
{
    private readonly DatabaseSink sink;

    public Executor(DatabaseSink sink)
    {
        this.sink = sink;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var usersToBeGenerated = 5;
        return this.sink.ProvisionAsync(usersToBeGenerated, cancellationToken);
    }
}
