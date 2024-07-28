namespace Sway.Database.Seeder.Sinks;

internal interface ISinkFactory
{
    ISink CreateSink(SwayEntity entity, SinkType destination);
}