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

internal class DatabaseSink<T> : ISink
{
    private readonly IGenerator<T> generator;
    private readonly IRepository<T> repository;

    public DatabaseSink(IGenerator<T> generator, IRepository<T> repository)
    {
        this.generator = generator;
        this.repository = repository;
    }

    public async Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        var entities = await this.generator.GenerateAsync(count, cancellationToken);

        foreach (var entity in entities)
        {
            await this.repository.CreateAsync(entity, cancellationToken);
        }
    }
}
