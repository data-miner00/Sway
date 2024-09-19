namespace Sway.Database.Seeder.Sinks;

using Sway.Core.Models;

/// <summary>
/// The sink factory.
/// </summary>
internal sealed class SinkFactory : ISinkFactory
{
    private readonly DatabaseSink<User> userDatabaseSink;
    private readonly SqlScriptSink<User> userSqlScriptSink;
    private readonly DatabaseSink<ProductRating> productRatingDatabaseSink;
    private readonly SqlScriptSink<ProductRating> productRatingSqlScriptSink;
    private readonly DatabaseSink<PaymentMethod> paymentDatabaseSink;
    private readonly SqlScriptSink<PaymentMethod> paymentSqlScriptSink;
    private readonly VoidSink voidSink;

    /// <summary>
    /// Initializes a new instance of the <see cref="SinkFactory"/> class.
    /// </summary>
    /// <param name="userDatabaseSink">The user database sink.</param>
    /// <param name="userSqlScriptSink">The user sql script sink.</param>
    /// <param name="productRatingDatabaseSink">The product rating database sink.</param>
    /// <param name="productRatingSqlScriptSink">The product rating sql script sink.</param>
    /// <param name="paymentDatabaseSink">The payment method database sink.</param>
    /// <param name="paymentSqlScriptSink">The payment method sql script sink.</param>
    /// <param name="voidSink">The void sink.</param>
    public SinkFactory(
        DatabaseSink<User> userDatabaseSink,
        SqlScriptSink<User> userSqlScriptSink,
        DatabaseSink<ProductRating> productRatingDatabaseSink,
        SqlScriptSink<ProductRating> productRatingSqlScriptSink,
        DatabaseSink<PaymentMethod> paymentDatabaseSink,
        SqlScriptSink<PaymentMethod> paymentSqlScriptSink,
        VoidSink voidSink)
    {
        this.userDatabaseSink = userDatabaseSink;
        this.userSqlScriptSink = userSqlScriptSink;
        this.productRatingDatabaseSink = productRatingDatabaseSink;
        this.productRatingSqlScriptSink = productRatingSqlScriptSink;
        this.paymentDatabaseSink = paymentDatabaseSink;
        this.paymentSqlScriptSink = paymentSqlScriptSink;
        this.voidSink = voidSink;
    }

    /// <inheritdoc/>
    public ISink CreateSink(SwayEntity entity, SinkType destination)
    {
        return (entity, destination) switch
        {
            (SwayEntity.User, SinkType.Database) => this.userDatabaseSink,
            (SwayEntity.User, SinkType.SqlScript) => this.userSqlScriptSink,
            (SwayEntity.ProductRating, SinkType.Database) => this.productRatingDatabaseSink,
            (SwayEntity.ProductRating, SinkType.SqlScript) => this.productRatingSqlScriptSink,
            (SwayEntity.PaymentMethod, SinkType.Database) => this.paymentDatabaseSink,
            (SwayEntity.PaymentMethod, SinkType.SqlScript) => this.paymentSqlScriptSink,
            _ => this.voidSink,
        };
    }
}
