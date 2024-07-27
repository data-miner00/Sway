namespace Sway.Database.Seeder;

using Autofac;

internal static class Program
{
    public static void Main(string[] args)
    {
        using var tokenSource = new CancellationTokenSource();

        var container = ContainerConfig.Configure();

        var executor = container.Resolve<IExecutor>();

        executor.ExecuteAsync(tokenSource.Token).GetAwaiter().GetResult();
    }
}
