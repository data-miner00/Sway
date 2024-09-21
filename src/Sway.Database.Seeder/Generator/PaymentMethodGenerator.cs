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
/// The generator class for <see cref="PaymentMethod"/>.
/// </summary>
internal sealed class PaymentMethodGenerator : IGenerator<PaymentMethod>
{
    private readonly Guid existingUserId;
    private readonly IEnumerable<PaymentType> paymentTypes;

    private readonly Dictionary<string, string> crytoProviders = new()
    {
        { "Bitcoin", "BTC" },
        { "Litecoin", "LTC" },
        { "Fantom", "FTM" },
        { "Ethereum", "ETH" },
        { "Avalanche", "AVAX" },
    };

    private readonly List<string> cardProviders = ["Visa", "MasterCard", "Amex"];
    private readonly List<string> cardIssuingBanks = ["Public Bank", "OCBC Bank", "Hong Leong Bank", "Maybank", "CIMB Bank"];
    private readonly List<string> ewalletProviders = ["Touch N Go", "Boost", "Grab Pay", "Alipay", "Sway", "Razer Pay"];

    private Faker<PaymentMethod> cryptoFaker;
    private Faker<PaymentMethod> cardFaker;
    private Faker<PaymentMethod> onlineBankingFaker;
    private Faker<PaymentMethod> ewalletFaker;

    /// <summary>
    /// Initializes a new instance of the <see cref="PaymentMethodGenerator"/> class.
    /// </summary>
    /// <param name="existingUserId">The existing user to be binded with the new payment methods.</param>
    /// <param name="paymentTypes">The payment type variants.</param>
    public PaymentMethodGenerator(Guid existingUserId, IEnumerable<PaymentType> paymentTypes)
    {
        this.existingUserId = Guard.ThrowIfDefault(existingUserId);
        this.paymentTypes = Guard.ThrowIfNull(paymentTypes).Distinct();

        this.ConfigureCardPaymentMethodFaker();
        this.ConfigureCryptocurrencyPaymentMethodFaker();
        this.ConfigureOnlineBankingPaymentMethodFaker();
        this.ConfigureEWalletPaymentMethodFaker();
    }

    /// <inheritdoc/>
    public Task<IEnumerable<PaymentMethod>> GenerateAsync(int count, CancellationToken cancellationToken)
    {
        cancellationToken.ThrowIfCancellationRequested();

        List<PaymentMethod> result = [];

        List<Faker<PaymentMethod>> generators = [];

        if (
            this.paymentTypes.Contains(PaymentType.CreditCard)
            || this.paymentTypes.Contains(PaymentType.DebitCard))
        {
            generators.Add(this.cardFaker);
        }

        if (this.paymentTypes.Contains(PaymentType.OnlineBanking))
        {
            generators.Add(this.onlineBankingFaker);
        }

        if (this.paymentTypes.Contains(PaymentType.Cryptocurrency))
        {
            generators.Add(this.cryptoFaker);
        }

        if (this.paymentTypes.Contains(PaymentType.EWallet))
        {
            generators.Add(this.ewalletFaker);
        }

        for (var i = count; i > 0; i--)
        {
            result.AddRange(generators[i % generators.Count].Generate(1));
        }

        return Task.FromResult(result.AsEnumerable());
    }

    private void ConfigureCardPaymentMethodFaker()
    {
        this.cardFaker = new Faker<PaymentMethod>()
            .RuleFor(x => x.UserId, s => this.existingUserId)
            .RuleFor(x => x.Type, s => s.PickRandom(PaymentType.DebitCard, PaymentType.CreditCard))
            .RuleFor(x => x.Provider, s => s.PickRandom(this.cardProviders))
            .RuleFor(x => x.CVV, s => s.Random.Int(100, 1000))
            .RuleFor(x => x.CardholderName, s => s.Name.FullName().Replace("'", "''"))
            .RuleFor(x => x.CardNumber, s => CreditCardNumberGenerator.GenerateMasterCardNumber())
            .RuleFor(x => x.CardIssuingCountry, s => s.Address.Country())
            .RuleFor(x => x.CardIssuingBank, s => s.PickRandom(this.cardIssuingBanks))
            .RuleFor(x => x.Currency, s => "MYR");
    }

    private void ConfigureCryptocurrencyPaymentMethodFaker()
    {
        this.cryptoFaker = new Faker<PaymentMethod>()
            .RuleFor(x => x.UserId, s => this.existingUserId)
            .RuleFor(x => x.Type, s => PaymentType.Cryptocurrency)
            .RuleFor(x => x.WalletAddress, s => s.Random.Hash())
            .RuleFor(x => x.Provider, s => s.PickRandom(this.crytoProviders.Keys.ToArray()))
            .RuleFor(x => x.Currency, (s, o) => this.crytoProviders[o.Provider]);
    }

    private void ConfigureOnlineBankingPaymentMethodFaker()
    {
        this.onlineBankingFaker = new Faker<PaymentMethod>()
            .RuleFor(x => x.UserId, s => this.existingUserId)
            .RuleFor(x => x.Type, s => PaymentType.OnlineBanking)
            .RuleFor(x => x.Provider, s => s.PickRandom(this.cardIssuingBanks))
            .RuleFor(x => x.Currency, s => "MYR");
    }

    private void ConfigureEWalletPaymentMethodFaker()
    {
        this.ewalletFaker = new Faker<PaymentMethod>()
            .RuleFor(x => x.UserId, s => this.existingUserId)
            .RuleFor(x => x.Type, s => PaymentType.EWallet)
            .RuleFor(x => x.Provider, s => s.PickRandom(this.ewalletProviders))
            .RuleFor(x => x.Currency, s => "MYR");
    }
}
