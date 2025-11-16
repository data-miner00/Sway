namespace Sway.Database.Seeder;

using Autofac;

/// <summary>
/// The database seeder.
/// </summary>
internal static class Program
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    /// <returns>The task.</returns>
    public static Task Main(string[] args)
    {
        using var tokenSource = new CancellationTokenSource();

        var container = ContainerConfig.Configure();

        var executor = container.Resolve<IExecutor>();

        return executor.ExecuteAsync(tokenSource.Token);
    }
}
