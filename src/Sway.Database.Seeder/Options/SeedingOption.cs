namespace Sway.Database.Seeder.Options;

using Sway.Core.Models;

/// <summary>
/// The configurations for generating <see cref="ProductRating"/>.
/// </summary>
/// <param name="ExistingProductId">The existing product Id.</param>
/// <param name="ExistingUserId">The existing user Id.</param>
internal record ProductRatingOption(Guid ExistingProductId, Guid ExistingUserId);

/// <summary>
/// The configurations for generating <see cref="PaymentMethod"/>.
/// </summary>
/// <param name="ExistingUserId">The existing user Id.</param>
/// <param name="PaymentTypes">The payment types to be generated.</param>
internal record PaymentMethodOption(Guid ExistingUserId, IEnumerable<PaymentType> PaymentTypes);

/// <summary>
/// The configurations pertaining to seeding.
/// </summary>
internal sealed class SeedingOption
{
    /// <summary>
    /// Gets or sets the destination which the generated entities should go to.
    /// </summary>
    public SinkType Destination { get; set; }

    /// <summary>
    /// Gets or sets the number of entites should be generated.
    /// </summary>
    public int Count { get; set; }

    /// <summary>
    /// Gets or sets the entity to be generated.
    /// </summary>
    public SwayEntity Entity { get; set; }

    /// <summary>
    /// Gets or sets the configurations for product rating.
    /// </summary>
    public ProductRatingOption ProductRatingOption { get; set; }

    /// <summary>
    /// Gets or sets the configurations for payment method.
    /// </summary>
    public PaymentMethodOption PaymentMethodOption { get; set; }
}
