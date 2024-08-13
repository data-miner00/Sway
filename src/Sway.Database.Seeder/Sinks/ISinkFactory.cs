namespace Sway.Database.Seeder.Sinks;

/// <summary>
/// The interface for the sink factory.
/// </summary>
internal interface ISinkFactory
{
    /// <summary>
    /// Creates a sink based on the entity and destination.
    /// </summary>
    /// <param name="entity">The Sway entity enum type.</param>
    /// <param name="destination">The sink destination.</param>
    /// <returns>The corresponding sink.</returns>
    ISink CreateSink(SwayEntity entity, SinkType destination);
}
