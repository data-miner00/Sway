namespace Sway.Database.Seeder;

using Autofac;
using Autofac.Configuration;
using Microsoft.Extensions.Configuration;
using Sway.Core.Models;
using Sway.Core.Repositories;
using Sway.Database.Seeder.Generator;
using Sway.Database.Seeder.Options;
using Sway.Database.Seeder.Sinks;
using Sway.Database.Seeder.Writers;
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
            .ConfigureFileNameBuilder()
            .ConfigureGenerators()
            .ConfigureDatabase()
            .ConfigureRepositories()
            .ConfigureSinks()
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

        var seedingOption =
            config.GetSection(nameof(SeedingOption)).Get<SeedingOption>()
            ?? throw new InvalidOperationException("The seeding option cannot be empty.");

        builder.RegisterInstance(seedingOption);

        var sqlSinkOption =
            config.GetSection(nameof(SqlSinkOption)).Get<SqlSinkOption>()
            ?? throw new InvalidOperationException("The seeding option cannot be empty.");

        // Make sure the directory exists
        Directory.CreateDirectory(sqlSinkOption.OutputPath);

        builder.RegisterInstance(sqlSinkOption);

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

    private static ContainerBuilder ConfigureFileNameBuilder(this ContainerBuilder builder)
    {
        builder.Register(
            ctx =>
            {
                var sinkOption = ctx.Resolve<SqlSinkOption>();

                return new SqlFileNameBuilder(sinkOption.OutputPath, sinkOption.NamingStrategy);
            })
            .AsSelf().SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureRepositories(this ContainerBuilder builder)
    {
        builder.RegisterType<UserRepository>().As<IRepository<User>>().SingleInstance();
        builder.RegisterType<UserSeedSqlWriter>().As<ISqlWriter<User>>().SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureGenerators(this ContainerBuilder builder)
    {
        builder.RegisterType<UserGenerator>().As<IGenerator<User>>().SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureSinks(this ContainerBuilder builder)
    {
        builder.RegisterType<DatabaseSink<User>>().AsSelf().SingleInstance();
        builder.RegisterType<SqlScriptSink<User>>().AsSelf().SingleInstance();
        builder.RegisterType<VoidSink>().AsSelf().SingleInstance();

        builder.RegisterType<SinkFactory>().As<ISinkFactory>().SingleInstance();

        return builder;
    }

    private static ContainerBuilder ConfigureEntryPoint(this ContainerBuilder builder)
    {
        builder.RegisterType<Executor>().As<IExecutor>().SingleInstance();

        return builder;
    }
}
