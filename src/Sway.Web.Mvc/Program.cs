using System.Data;
using System.Data.SqlClient;
using Sway.Core.Repositories;
using Sway.Integrations.Repositories;

var builder = WebApplication.CreateBuilder(args);

ConfigureDatabase(builder);

builder.Services.AddControllersWithViews();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();
builder.Services.AddSingleton<IUserRepository, UserRepository>();
builder.Services.AddSingleton<IShoppingCartRepository, ShoppingCartRepository>();
builder.Services.AddSingleton<IProductRatingRepository, ProductRatingRepository>();
builder.Services.AddSingleton<IFavouriteRepository, FavouriteRepository>();
builder.Services.AddSingleton<IAddressRepository, AddressRepository>();
builder.Services.AddSingleton<IPaymentMethodRepository, PaymentMethodRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

static void ConfigureDatabase(WebApplicationBuilder builder)
{
    var dbConnectionString = builder.Configuration.GetConnectionString("Database");
    var connection = new SqlConnection(dbConnectionString);
    builder.Services.AddSingleton<IDbConnection>(connection);
}
