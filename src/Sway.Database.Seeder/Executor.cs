namespace Sway.Database.Seeder;

using Sway.Database.Seeder.Options;
using Sway.Database.Seeder.Sinks;
using System.Threading.Tasks;

internal sealed class Executor : IExecutor
{
    private readonly ISink sink;
    private readonly SeedingOption option;

    public Executor(ISinkFactory sinkFactory, SeedingOption option)
    {
        this.sink = sinkFactory.CreateSink(option.Entity, option.Destination);
        this.option = option;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var usersToBeGenerated = this.option.Count;
        return this.sink.ProvisionAsync(usersToBeGenerated, cancellationToken);
    }
}
