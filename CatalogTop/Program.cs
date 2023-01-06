using CatalogTop.Models;
using CatalogTop.Services;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<AppDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DBcontext")));

// схема аутентификации с помощью cookie
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, (conf) => conf.LoginPath = "/Account/Login");
builder.Services.AddAuthorization();

// репозиторий - антипатерн, не используется
builder.Services.AddTransient<IAccountService, AccountService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//TODO: Login Controller
//TODO: Add Claims?

//Scaffold-DbContext "Host=localhost;Database=test;Username=postgres;Password=pas" Npgsql.EntityFrameworkCore.PostgreSQL -OutputDir Models2