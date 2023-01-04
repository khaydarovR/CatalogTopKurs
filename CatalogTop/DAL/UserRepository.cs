using CatalogTop.Models;
using CatalogTop.Models.Account;
using Microsoft.EntityFrameworkCore;

namespace CatalogTop.DAL
{
    public class UserRepository: IUserRepository
    {
        private CatalogDbContext _context;

        public UserRepository(CatalogDbContext context)
        {
            this._context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserByID(long id)
        {
            return _context.Users.Find(id);
        }

        public void InsertUser(User User)
        {
            _context.Users.Add(User);
        }

        public void DeleteUser(int UserID)
        {
            User User = _context.Users.Find(UserID);
            _context.Users.Remove(User);
        }

        public void UpdateUser(User User)
        {
            _context.Entry(User).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        async Task IUserRepository.InsertUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
        }
    }
}
