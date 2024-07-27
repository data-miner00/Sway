namespace Sway.Database.Seeder;

using Sway.Database.Seeder.Generator;
using System.Threading.Tasks;

internal sealed class Executor : IExecutor
{
    private readonly UserGenerator userGenerator;

    public Executor(UserGenerator userGenerator)
    {
        this.userGenerator = userGenerator;
    }

    public Task ExecuteAsync(CancellationToken cancellationToken)
    {
        var usersToBeGenerated = 5;
        return this.userGenerator.ProvisionAsync(usersToBeGenerated, cancellationToken);
    }
}
