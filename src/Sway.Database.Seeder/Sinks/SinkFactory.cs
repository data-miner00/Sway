namespace Sway.Database.Seeder.Sinks;

internal sealed class SinkFactory : ISinkFactory
{
    private readonly DatabaseSink databaseSink;
    private readonly SqlScriptSink sqlScriptSink;
    private readonly VoidSink voidSink;

    public SinkFactory(
        DatabaseSink databaseSink,
        SqlScriptSink sqlScriptSink,
        VoidSink voidSink)
    {
        this.databaseSink = databaseSink;
        this.sqlScriptSink = sqlScriptSink;
        this.voidSink = voidSink;
    }

    public ISink CreateSink(SwayEntity entity, SinkType destination)
    {
        return (entity, destination) switch
        {
            (SwayEntity.User, SinkType.Database) => this.databaseSink,
            (SwayEntity.User, SinkType.SqlScript) => this.sqlScriptSink,
            _ => this.voidSink,
        };
    }
}
