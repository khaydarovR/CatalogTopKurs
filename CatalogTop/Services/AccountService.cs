using CatalogTop.Data;
using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace CatalogTop.Services
{
    public class AccountService : IAccountService
    {
        private AppDbContext _dBContext;
        public AccountService(AppDbContext dbContext)
        {
            this._dBContext = dbContext;
        }

        public async Task<User> RegisterAccount(RegisterViewModel registerViewModel)
        {

            var haveThisEmail = _dBContext.Users.Any(u => u.Email == registerViewModel.Email);

            if (haveThisEmail)
            {
                throw new Exception("Такой Email уже существует");
            }

            var newUser = DTO.UserMapper.UserMap(registerViewModel);

            await _dBContext.Users.AddAsync(newUser);
            _dBContext.SaveChanges();

            
            newUser = await _dBContext.Users.FirstAsync(u => u.Email==registerViewModel.Email);
            return newUser;
        }

        public ClaimsPrincipal GetClaimsPrincipalDefault (User user)
        {
            long _id = _dBContext.Users.First(u => u.Email == user.Email).Id;
            var claims = new List<Claim>
            {
                new Claim("id", user.Id.ToString(), ClaimValueTypes.Integer),
                new Claim(ClaimTypes.Role, user.Status),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Name, user.Email)
            };

            var claimIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);

            return claimPrincipal;
        }

        public Task<User> Login(LoginViewModel loginViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
