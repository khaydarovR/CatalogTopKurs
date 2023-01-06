using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;
using System.Security.Claims;

namespace CatalogTop.Services
{
    public interface IAccountService
    {
        Task<User> RegisterAccount(RegisterViewModel registerViewModel);

        Task<User> Login(LoginViewModel loginViewModel);

        ClaimsPrincipal GetClaimsPrincipalDefault(User user);
    }
}
