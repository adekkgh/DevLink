using DevLink.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DevLink.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public AuthController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Login()
        {
            if (Request.Cookies["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult LogOut()
        {
            foreach (var cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }

            return RedirectToAction("LogIn", "Auth");
        }

        public IActionResult LogIntoAccount(string email, string password, bool remember)
        {
            if (Request.Cookies["user"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = usersRepository.FindByEmail(email);
            var isPasswordValid = usersRepository.IsPasswordValid(email, password);

            if (user == null)
            {
                ModelState.AddModelError(String.Empty, "Пользователя с таким логином не существует");
                return View("Login");
            }
            if (!isPasswordValid)
            {
                ModelState.AddModelError(String.Empty, "Неверный пароль");
                return View("Login");
            }

            CookieOptions option = new CookieOptions();
            if (remember)
            {
                option.Expires = DateTime.Now.AddDays(7);
            }
            else
            {
                option.Expires = DateTime.Now.AddDays(1);
            }

            Response.Cookies.Append("user", user.Id.ToString(), option);
            Response.Cookies.Append("role", user.Role, option);
            return RedirectToAction("Index", "Home");
        }
    }
}
