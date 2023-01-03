using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;

namespace CatalogTop.Services
{
    public interface IAccountService
    {
        Task<string> RegisterAccount(RegisterViewModel registerViewModel);
    }
}
