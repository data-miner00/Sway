namespace Sway.Database.Seeder.Sinks;

using Sway.Core.Models;
using Sway.Database.Seeder.Generator;
using Sway.Database.Seeder.Writers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

internal class SqlScriptSink : ISink
{
    private readonly UserGenerator generator;
    private readonly ISqlWriter<User> writer;

    public SqlScriptSink(UserGenerator generator, ISqlWriter<User> writer)
    {
        this.generator = generator;
        this.writer = writer;
    }

    public async Task ProvisionAsync(int count, CancellationToken cancellationToken)
    {
        var users = await this.generator.GenerateAsync(count, cancellationToken);

        await this.writer.BulkWriteAsync(users, cancellationToken);
        await Console.Out.WriteLineAsync("Writing done.");
    }
}
