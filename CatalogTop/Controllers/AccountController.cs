using CatalogTop.DAL;
using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.Services;
using CatalogTop.ViewModels.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System;
using System.Linq;

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
        public string Index()
        {
            return $"User info: " + User.Identity.Name + User.Identity.AuthenticationType;
        }

        [HttpGet]
        public IActionResult Register() => View();

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // ASK: передача бдконтекста и сервиса для управления акк -> сервис сохраняет с помощью репозитория
                await _accountService.RegisterAccount(model);

                return Content($"{model.Email} - {model.Password}");
            }
            else
            {
                return View(model);
            }
        }

        public IActionResult Login()
        {
            return View();
        }
    }
}
