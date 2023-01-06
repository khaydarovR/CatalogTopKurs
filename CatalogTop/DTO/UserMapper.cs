using CatalogTop.Helpers;
using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;
using System.Data;

namespace CatalogTop.DTO
{
    public static class UserMapper
    {
        public static User UserMap(RegisterViewModel registerViewModel)
        {
            var newUser = new User()
            {
                Email = registerViewModel.Email,
                Password = MyHelpers.GetHashSaltString(registerViewModel.Password),
                Coin = 0,
                LastVisit = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                Status = Data.UserStatus.User,
            };

            return newUser;
        }
    }
}
