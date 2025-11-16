namespace Sway.Database.Seeder.Generator;

using Bogus;
using Sway.Common;
using Sway.Core.Models;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

/// <summary>
/// The coupon generator.
/// </summary>
internal class CouponGenerator : IGenerator<Coupon>
{
    private readonly Guid existingUserId;
    private Faker<Coupon> couponFaker = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="CouponGenerator"/> class.
    /// </summary>
    /// <param name="existingUserId">The user to mint the coupons to.</param>
    public CouponGenerator(Guid existingUserId)
    {
        this.existingUserId = Guard.ThrowIfDefault(existingUserId);

        this.ConfigureCouponFaker();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<Coupon>> GenerateAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();
        Guard.ThrowIfLessThan(count, 0);

        return Task.FromResult<IEnumerable<Coupon>>(this.couponFaker.Generate(count));
    }

    private void ConfigureCouponFaker()
    {
        this.couponFaker = new Faker<Coupon>()
            .RuleFor(c => c.Id, f => Guid.NewGuid())
            .RuleFor(c => c.Code, f => f.Random.AlphaNumeric(10).ToUpper())
            .RuleFor(c => c.Description, f => f.Lorem.Text())
            .RuleFor(c => c.DiscountAmount, f => f.Random.Int(5, 50))
            .RuleFor(c => c.DiscountUnit, f => f.PickRandom(DiscountType.Flat, DiscountType.Percentage))
            .RuleFor(c => c.ExpireAt, f => f.Date.FutureOffset(30).DateTime)
            .RuleFor(c => c.OwnerId, f => this.existingUserId)
            .RuleFor(c => c.CreatedAt, f => f.Date.RecentOffset(30).DateTime)
            .RuleFor(c => c.ModifiedAt, (f, c) => f.Date.BetweenOffset(c.CreatedAt.Date, DateTimeOffset.Now).DateTime);
    }
}
