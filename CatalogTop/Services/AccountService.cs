using CatalogTop.DAL;
using CatalogTop.Models;
using CatalogTop.Models.Account;
using CatalogTop.ViewModels.Account;
using System.Data;
using System.Linq.Expressions;

namespace CatalogTop.Services
{
    public class AccountService : IAccountService
    {
        private CatalogDbContext _dBContext;
        private IUserRepository _userRepository;

        //ASK: Так можно внедрять?
        public AccountService(CatalogDbContext dbContext, IUserRepository userRepository) 
        {
            this._dBContext = dbContext;
            this._userRepository = userRepository;
        }

        public Task<string> RegisterAccount(RegisterViewModel registerViewModel)
        {
            throw new NotImplementedException();
        }

        //public async Task<User> RegisterAccount(RegisterViewModel registerViewModel)
        //{
        //    //проверка на уникальность

        //    //mapper reggisterViewModel -> Model (User)
        //    var newUser = new User() { Email = registerViewModel.Email };

        //    try
        //    {
        //        _userRepository.InsertUser(newUser);
        //        await _userRepository.GetUser().ToArray();
        //    }
        //    catch (DataException)
        //    {
        //        await new Task(new Task("Error"));
        //    }
        //}

        //return Task<string>("ok");
        //ASK: Для сохранения нового пользователя так??
        //TODO: Спросить и доделать
    }
}
