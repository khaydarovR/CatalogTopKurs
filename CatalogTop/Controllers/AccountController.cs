using CatalogTop.DAL;
using CatalogTop.Helpers;
using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.Services;
using CatalogTop.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NuGet.Protocol;
using System;
using System.Linq;
using System.Security.Claims;

namespace CatalogTop.Controllers
{
    public class AccountController : Controller
    {
        private CatalogDbContext _dbContext;
        private IAccountService _accountService;
        private IUserRepository _userRepository;


        public AccountController(
            CatalogDbContext dBContext,
            IAccountService accountService,
            IUserRepository userRepository) 
            //ASK: Сам найдет нужную реализацию и зависемости? + внедрит нужные зависемости для самого userRepository я
        {
            _dbContext= dBContext;
            _accountService = accountService;
            _userRepository = userRepository;
        }

        [Authorize]
        public IActionResult Index()
        {
            List<Claim> res = HttpContext.User.Claims.ToList();
            //Сохранение -> его поиск -> сохранение в claims id пользователя
            var test = HttpContext.User;
            //User model = _userRepository.GetUserByID(0);
            return View(res);
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await _accountService.RegisterAccount(model);


            var claims = new List<Claim>
            {
                new Claim("Status", Helpers.DbInit.GetEnumDescription(UserStatusEnum.NewUser))
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme); 
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claimPrincipal);

            return Redirect("/Account");
        }

        public IActionResult Login(string returnUrl)
        {
            ViewBag.returnUrl = returnUrl;
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
