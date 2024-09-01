namespace Sway.Database.Seeder.Sinks;

using Sway.Database.Seeder.Generator;
using Sway.Database.Seeder.Writers;
using System;
using System.Threading;
using System.Threading.Tasks;

internal class SqlScriptSink<T> : ISink
{
    private readonly IGenerator<T> generator;
    private readonly ISqlWriter<T> writer;

    public SqlScriptSink(IGenerator<T> generator, ISqlWriter<T> writer)
    {
        this.generator = generator;
        this.writer = writer;
    }

    public async Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        var entities = await this.generator.GenerateAsync(count, cancellationToken);

        await this.writer.BulkWriteAsync(entities, cancellationToken);
        await Console.Out.WriteLineAsync("Writing done.");
    }
}
