namespace Sway.Database.Seeder.Sinks;

using Sway.Core.Models;

/// <summary>
/// The sink factory.
/// </summary>
internal sealed class SinkFactory : ISinkFactory
{
    private readonly DatabaseSink<User> userDatabaseSink;
    private readonly SqlScriptSink<User> userSqlScriptSink;
    private readonly VoidSink voidSink;

    /// <summary>
    /// Initializes a new instance of the <see cref="SinkFactory"/> class.
    /// </summary>
    /// <param name="userDatabaseSink">The user database sink.</param>
    /// <param name="userSqlScriptSink">The user sql script sink.</param>
    /// <param name="voidSink">The void sink.</param>
    public SinkFactory(
        DatabaseSink<User> userDatabaseSink,
        SqlScriptSink<User> userSqlScriptSink,
        VoidSink voidSink)
    {
        this.userDatabaseSink = userDatabaseSink;
        this.userSqlScriptSink = userSqlScriptSink;
        this.voidSink = voidSink;
    }

    /// <inheritdoc/>
    public ISink CreateSink(SwayEntity entity, SinkType destination)
    {
        return (entity, destination) switch
        {
            (SwayEntity.User, SinkType.Database) => this.userDatabaseSink,
            (SwayEntity.User, SinkType.SqlScript) => this.userSqlScriptSink,
            _ => this.voidSink,
        };
    }
}
