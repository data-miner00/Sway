namespace Sway.Database.Seeder;

using Sway.Database.Seeder.Generator;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
        return this.userGenerator.ProvisionAsync(20, cancellationToken);
    }
}
