namespace Sway.Database.Seeder.Sinks;

using System.Threading;
using System.Threading.Tasks;

internal sealed class VoidSink : ISink
{
    public Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}
