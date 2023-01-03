using CatalogTop.DAL;
using CatalogTop.Models;
using CatalogTop.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<CatalogDbContext>(options =>
options.UseNpgsql(builder.Configuration.GetConnectionString("DBcontext")));

builder.Services.AddAuthentication("Cookies")  // схема аутентификации - с помощью cookie
    .AddCookie();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IAccountService ,AccountService>(); // сервис для управления учетными записями (аккаунтами)

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
app.UseAuthentication();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

//TODO: сделать миграцию?
//TODO: протестировать areas -> Проблемы с общими файлами
//TODO: система регистрации

//ASK: Архитектура вообще правильная? правильно иду? что исправить?
//ASK: Нужно ли в сервисы внедрять IUserRepository