using CatalogTop.DAL;
using CatalogTop.Helpers;
using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;
using Microsoft.EntityFrameworkCore;
using System.Data;
namespace CatalogTop.Services
{
    public class AccountService : IAccountService
    {
        private CatalogDbContext _dBContext;
        private IUserRepository _userRepository;

        //ASK: Так можно внедрять?
        public AccountService(IUserRepository userRepository, CatalogDbContext dbContext) 
        {
            this._dBContext = dbContext;
            this._userRepository = userRepository;
        }

        //public Task<string> RegisterAccount(RegisterViewModel registerViewModel)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task RegisterAccount(RegisterViewModel registerViewModel)
        {
            IEnumerable<User> users = _userRepository.GetUsers();

            var haveThisEmail = users.Any(u => u.Email == registerViewModel.Email);

            if(haveThisEmail)
            {
                throw new Exception("This is Email has in DB");
            }
            //mapper reggisterViewModel -> Model (User)

            var newUser = new User() {
                Email = registerViewModel.Email,
                Password = registerViewModel.Password,
                LastVisit = new DateOnly(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day),
                StatusNavigation = _dBContext.Statuses.Where(s => s.Title == "Новый пользователь").FirstOrDefault(),
                Coin = 0
            };

            try
            {
                await _userRepository.InsertUserAsync(newUser);
                _userRepository.Save();
            }
            catch (DataException)
            {
                throw new Exception("Error with saves in DB");
            }
        }

        //return Task<string>("ok");
        //ASK: Для сохранения нового пользователя так??
        //TODO: Спросить и доделать
    }
}
