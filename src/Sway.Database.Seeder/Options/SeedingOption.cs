namespace Sway.Database.Seeder.Options;

internal sealed class SeedingOption
{
    public SinkType Destination { get; set; }

    public int Count { get; set; }

    public SwayEntity Entity { get; set; }
}
