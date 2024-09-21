namespace Sway.Database.Seeder.Options;

using Sway.Core.Models;

internal record ProductRatingOption(Guid ExistingProductId, Guid ExistingUserId);

internal record PaymentMethodOption(Guid ExistingUserId, IEnumerable<PaymentType> PaymentTypes);

internal sealed class SeedingOption
{
    public SinkType Destination { get; set; }

    public int Count { get; set; }

    public SwayEntity Entity { get; set; }

    public ProductRatingOption ProductRatingOption { get; set; }

    public PaymentMethodOption PaymentMethodOption { get; set; }
}
