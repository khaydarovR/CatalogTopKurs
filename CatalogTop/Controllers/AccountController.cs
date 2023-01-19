using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.Services;
using CatalogTop.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace CatalogTop.Controllers
{
    public class AccountController : Controller
    {
        private AppDbContext _dbContext;
        private IAccountService _accountService;


        public AccountController(
            AppDbContext dBContext,
            IAccountService accountService)
        {
            _dbContext = dBContext;
            _accountService = accountService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var _id = long.Parse(s: HttpContext.User.FindFirst("id").Value);
            User model = await _dbContext.Users.FirstAsync(u => u.Id == _id);

            return View(model);
        }


        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            User res;
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            try
            {
                res = await _accountService.RegisterAccount(model);
            }
            catch(Exception e)
            {
                ModelState.AddModelError("Ошибка регистрации", e.Message);
                return View(model);
            }

            var principal = _accountService.GetClaimsPrincipalDefault(res);
            await HttpContext.SignInAsync(principal);

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
