using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.Services;
using CatalogTop.ViewModels.Account;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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
