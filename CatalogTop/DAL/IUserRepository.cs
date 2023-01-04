using CatalogTop.Models.Account;

namespace CatalogTop.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUsers();
        User GetUserByID(long userId);
        void InsertUser(User user);
        Task InsertUserAsync(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}
