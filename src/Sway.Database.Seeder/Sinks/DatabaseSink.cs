namespace Sway.Database.Seeder.Sinks;

using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Database.Seeder.Generator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class DatabaseSink : ISink
{
    private readonly UserGenerator generator;
    private readonly IUserRepository repository;

    public DatabaseSink(UserGenerator generator, IUserRepository repository)
    {
        this.generator = generator;
        this.repository = repository;
    }

    public async Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        var users = await this.generator.GenerateAsync(count, cancellationToken);

        foreach (var user in users)
        {
            await this.repository.CreateAsync(user, cancellationToken);
        }
    }
}
