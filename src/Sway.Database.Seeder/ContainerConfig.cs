namespace Sway.Database.Seeder;

using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Sway.Core.Repositories;
using Sway.Database.Seeder.Generator;
using Sway.Database.Seeder.Options;
using Sway.Integrations.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal static class ContainerConfig
{
    public static IContainer Configure()
    {
        var builder = new ContainerBuilder();

        builder
            .ConfigureOptions()
            .ConfigureDatabase()
            .ConfigureRepositories()
            .ConfigureEntryPoint();

        return builder.Build();
    }

    private static ContainerBuilder ConfigureOptions(this ContainerBuilder builder)
    {
        var configBuilder = new ConfigurationBuilder();
        configBuilder.AddJsonFile("appsettings.json");

        var config = configBuilder.Build();

        var module = new ConfigurationModule(configBuilder.Build());

        builder.RegisterModule(module);

        var databaseOption =
            config.GetSection(nameof(DatabaseOption)).Get<DatabaseOption>()
            ?? throw new InvalidOperationException("The database option cannot be empty.");

        builder.RegisterInstance(databaseOption);

        return builder;
    }

    private static ContainerBuilder ConfigureDatabase(this ContainerBuilder builder)
    {
        builder.Register(
            ctx =>
                {
                    var option = ctx.Resolve<DatabaseOption>();

                    var connection = new SqlConnection(option.ConnectionString);

                    return connection;
                })
            .As<IDbConnection>()
            .SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureRepositories(this ContainerBuilder builder)
    {
        builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
        builder.RegisterType<UserGenerator>().AsSelf().SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureEntryPoint(this ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().As<IExecutor>().SingleInstance();

        return builder;
    }
}
