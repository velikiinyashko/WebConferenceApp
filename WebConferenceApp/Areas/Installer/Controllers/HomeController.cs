using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebConferenceApp.Models;
using WebConferenceApp.Models.Billing;

namespace WebConferenceApp.Areas.Installer.Controllers
{
    [Area("Installer")]
    public class HomeController : Controller
    {
        private BaseContext _context;

        public HomeController(BaseContext context)
        {
            _context = context;
        }

        private void Initialization()
        {

            Role AdminRole = new Role { Name = "Administrator" };
            Role UserRole = new Role { Name = "User" };
            Role ModRole = new Role { Name = "Moderator" };

            TypeAccount TypeFiz = new TypeAccount { Name = "Физическое лицо" };
            TypeAccount TypeUr = new TypeAccount { Name = "Юридическое лицо" };

            Status StatusOpen = new Status { Name = "Открыта" };
            Status StatusClose = new Status { Name = "Закрыта" };

            Company CompanySibItPro = new Company { Name = "SibItProject", City = "Красноярск" };

            Contract ContractSibItPro = new Contract { Uid = Guid.NewGuid(), CteateTime = DateTime.Now, Balance = 1000 };

            Account Administrator = new Account { Login = "Admin", Password = HashMD5("Admin"), Role = AdminRole, Email = "admin@sibitproject.ru", Phone = "+79607522216", Name = "Сергей", SecondName = "Иванов", SurName = "Александнович", Company = CompanySibItPro, TypeAccount = TypeUr, Contract = ContractSibItPro };

            _context.TypeAccounts.Add(TypeFiz);
            _context.TypeAccounts.Add(TypeUr);
            _context.Status.Add(StatusOpen);
            _context.Status.Add(StatusClose);
            _context.Roles.Add(AdminRole);
            _context.Roles.Add(ModRole);
            _context.Roles.Add(UserRole);
            _context.Accounts.Add(Administrator);

            _context.SaveChangesAsync();
        }

        public string HashMD5(string text)
        {
            using (MD5 Md5Hash = MD5.Create())
            {
                byte[] data = Md5Hash.ComputeHash(Encoding.UTF8.GetBytes(text));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    builder.Append(data[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public IActionResult Index()
        {
            Initialization();
            return View();
        }
    }
}