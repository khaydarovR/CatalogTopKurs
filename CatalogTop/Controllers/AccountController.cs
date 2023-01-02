using CatalogTop.Models;
using CatalogTop.Models.Account;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CatalogTop.Controllers
{
    public class AccountController : Controller
    {
        private DBContext _dbContext;
        public AccountController(DBContext dBContext) 
        {
            _dbContext= dBContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        public string List()
        {
            string names = "";
            List<Status> types = _dbContext.Statuses.ToList();
            foreach (var item in types)
            {
                names += item.Title;
                names += "\n";
            }

            return names;
        }

        public string Add()
        {
            _dbContext.Statuses.Add(new Status() { Title = "admin "+new Random().Next(10) });
            _dbContext.SaveChanges();
            return "Ok";
        }
    }
}
