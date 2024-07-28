namespace Sway.Database.Seeder.Sinks;

using System.Threading.Tasks;

internal interface ISink
{
    Task ProvisionAsync(int count, CancellationToken cancellationToken);
}
