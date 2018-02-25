using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebConferenceApp.Models;
using WebConferenceApp.Models.Billing;
using WebConferenceApp.Areas.Cabinet.ViewModels;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace copts.Areas.cabinet.Controllers
{
    [Area("cabinet")]
    public class HomeController : Controller
    {
        private BaseContext _context;

        public HomeController(BaseContext context)
        {
            _context = context;
        }

        [Authorize]
        public async Task<IActionResult> Index(string Name)
        {
            string UserName = HttpContext.User.Identity.Name.ToString();
            Account user = await _context.Accounts
                .Include(c => c.Contract)
                .Include(r => r.Rooms)
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Name == Name);
            if(user != null)
            {
                return View(user);
            }
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel lm)
        {

            if (ModelState.IsValid)
            {
                string passwd = HashMD5(lm.Password);
                Account AccUser = await _context.Accounts
                    .Include(u => u.Role)
                    .FirstOrDefaultAsync(u => u.Login == lm.Login && u.Password == passwd);
                if (AccUser != null)
                {
                    await GetCookie(AccUser);

                    return RedirectToAction("Index");
                }
                ModelState.AddModelError("", "Не корректные логин и(или) пароль");
            }
            return View(lm);
        }

        [HttpGet]
        public async Task<IActionResult> Registration()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegisterViewModel register)
        {
            if (ModelState.IsValid)
            {
                Account user = await _context.Accounts.FirstOrDefaultAsync(u => u.Login == register.Login);
                if (user == null)
                {
                    string passwd = HashMD5(register.Password);
                    Contract contract = new Contract { Uid = Guid.NewGuid(), CteateTime = DateTime.Now, Balance = 10 };
                    user = new Account { Login = register.Login, Password = passwd, Email = register.Email, Phone = register.Phone, Contract = contract, Name = register.Name, SecondName = register.SecondName, SurName = register.SurName };
                    Role userRole = await _context.Roles.FirstOrDefaultAsync(r => r.Name == "User");
                    if (userRole != null)
                    {
                        user.Role = userRole;
                    }
                    _context.Accounts.Add(user);
                    await _context.SaveChangesAsync();

                    await GetCookie(user);

                    return RedirectToAction("index");
                }
                ModelState.AddModelError("", "Не корректные логин и(или) пароль");
            }
            return View(register);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("index");
        }

        [HttpGet]
        public async Task<IActionResult> CreateRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoom(Room room)
        {
            if (ModelState.IsValid)
            {
                Room rooms = await _context.Rooms.FirstOrDefaultAsync(r => r.Name == room.Name);
                if(rooms != null)
                {
                    await _context.Rooms.AddAsync(room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction("index", "home", "cabinet");
                }
            }
            return View(room);
        }

        [HttpGet]
        public async Task<IActionResult> EditRoom()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> EditRoom(int? Id)
        {

            return View();
        }

        public async Task<IActionResult> DeleteRoom()
        {
            return View();
        }

        private async Task GetCookie(Account account)
        {
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, account.Login),
                new Claim(ClaimTypes.Role, account.Role?.Name),
                new Claim(ClaimTypes.Email, account.Email)
            };

            var ClaimsIdentity = new ClaimsIdentity(Claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var AuthProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(120)
            };

            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(ClaimsIdentity), AuthProperties);
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
    }
}