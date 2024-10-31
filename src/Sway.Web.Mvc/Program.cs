namespace Sway.Web.Mvc;

using System.Data;
using System.Data.SqlClient;
using Sway.Core.Repositories;
using Sway.Integrations.Repositories;

/// <summary>
/// The main program.
/// </summary>
public static class Program
{
    /// <summary>
    /// The entry point for the program.
    /// </summary>
    /// <param name="args">The command line arguments.</param>
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder
            .ConfigureDatabase()
            .ConfigureRepositories();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        app.Run();
    }

    private static WebApplicationBuilder ConfigureDatabase(this WebApplicationBuilder builder)
    {
        var dbConnectionString = builder.Configuration.GetConnectionString("Database");
        var connection = new SqlConnection(dbConnectionString);
        builder.Services.AddSingleton<IDbConnection>(connection);

        return builder;
    }

    private static WebApplicationBuilder ConfigureRepositories(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IProductRepository, ProductRepository>();
        builder.Services.AddSingleton<IUserRepository, UserRepository>();
        builder.Services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
        builder.Services.AddSingleton<IProductRatingRepository, ProductRatingRepository>();
        builder.Services.AddSingleton<IFavouriteRepository, FavouriteRepository>();
        builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
        builder.Services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>();
        builder.Services.AddSingleton<ICredentialRepository, CredentialRepository>();
        builder.Services.AddSingleton<INotificationRepository, NotificationRepository>();

        return builder;
    }
}
