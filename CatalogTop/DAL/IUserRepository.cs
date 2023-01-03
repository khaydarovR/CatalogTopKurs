using CatalogTop.Models.Account;

namespace CatalogTop.DAL
{
    public interface IUserRepository
    {
        IEnumerable<User> GetUser();
        User GetUserByID(int userId);
        void InsertUser(User user);
        void DeleteUser(int userID);
        void UpdateUser(User user);
        void Save();
    }
}
