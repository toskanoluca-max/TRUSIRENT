using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TRUSIRENT.Models;
using TRUSIRENT.Models.Repositories;

var builder = WebApplication.CreateBuilder(args);

var connectionString = builder.Configuration.GetConnectionString("TrusiRentDbContextConnection")
    ?? throw new InvalidOperationException("Connection string 'TrusiRentDbContextConnection' not found.");

builder.Services.AddDbContext<TrusiRentDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddEntityFrameworkStores<TrusiRentDbContext>();

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddSession();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<IVehicleRepository, VehicleRepository>();
builder.Services.AddScoped<IVehicleTypeRepository, VehicleTypeRepository>();
builder.Services.AddScoped<IRentalRepository, RentalRepository>();

builder.Services.AddScoped<IRentalCart>(sp => RentalCart.GetCart(sp));

var app = builder.Build();

app.UseStaticFiles();
app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapRazorPages();
app.MapDefaultControllerRoute();

app.Run();