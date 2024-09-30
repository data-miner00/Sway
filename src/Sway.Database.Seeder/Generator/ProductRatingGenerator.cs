namespace Sway.Database.Seeder.Generator;

using Bogus;
using Sway.Common;
using Sway.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The generator class for <see cref="ProductRating"/>.
/// </summary>
internal sealed class ProductRatingGenerator : IGenerator<ProductRating>
{
    private readonly Guid existingProductId;
    private readonly Guid existingUserId;
    private Faker<ProductRating> faker;

    /// <summary>
    /// Initializes a new instance of the <see cref="ProductRatingGenerator"/> class.
    /// </summary>
    /// <param name="existingProductId">The existing product to be binded.</param>
    /// <param name="existingUserId">The existing user who make the rating.</param>
    public ProductRatingGenerator(Guid existingProductId, Guid existingUserId)
    {
        this.existingProductId = Guard.ThrowIfDefault(existingProductId);
        this.existingUserId = Guard.ThrowIfDefault(existingUserId);

        this.ConfigureProductRatingFaker();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<ProductRating>> GenerateAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        return Task.FromResult(this.faker.Generate(count).AsEnumerable());
    }

    private void ConfigureProductRatingFaker()
    {
        this.faker = new Faker<ProductRating>()
            .RuleFor(x => x.ProductId, s => this.existingProductId)
            .RuleFor(x => x.AuthorId, s => this.existingUserId)
            .RuleFor(x => x.Rating, s => s.Random.Int(1, 5))
            .RuleFor(x => x.Comment, s => s.Random.String2(50));
    }
}
