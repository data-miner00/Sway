namespace Sway.Database.Seeder;

internal interface IExecutor
{
    Task ExecuteAsync(CancellationToken cancellationToken);
}
