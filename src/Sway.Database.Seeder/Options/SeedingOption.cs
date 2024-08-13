namespace Sway.Database.Seeder.Options;

internal record ProductRatingOption(Guid ExistingProductId, Guid ExistingUserId);

internal sealed class SeedingOption
{
    public SinkType Destination { get; set; }

    public int Count { get; set; }

    public SwayEntity Entity { get; set; }

    public ProductRatingOption ProductRatingOption { get; set; }
}
