using DevLink.Db;
using DevLink.Db.Models;
using DevLink.Models;
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
            if (Request.Cookies["userGuid"] != null)
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

        public IActionResult SignUp()
        {
            if (Request.Cookies["userGuid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public IActionResult LogIntoAccount(string email, string password, bool remember)
        {
            if (Request.Cookies["userGuid"] != null)
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

            Response.Cookies.Append("userGuid", user.Id.ToString(), option);
            Response.Cookies.Append("role", user.Role, option);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CreateNewAccount(UserViewModel createdUser)
        {
            if (Request.Cookies["userGuid"] != null)
            {
                return RedirectToAction("Index", "Home");
            }

            if (createdUser.NewPassword == createdUser.FirstName)
            {
                ModelState.AddModelError(String.Empty, "Пароль не должен совпадать с именем");
                return View("SignUp");
            }
            else if (createdUser.NewPassword == createdUser.LastName)
            {
                ModelState.AddModelError(String.Empty, "Пароль не должен совпадать с фамилией");
                return View("SignUp");
            }
            else if (createdUser.NewPassword == createdUser.UserName)
            {
                ModelState.AddModelError(String.Empty, "Пароль не должен совпадать с никнеймом");
                return View("SignUp");
            }

            var existingUserByEmail = usersRepository.FindByEmail(createdUser.Email);
            var existingUserByUsername = usersRepository.FindByUsername(createdUser.UserName);

            if (existingUserByUsername != null)
            {
                ModelState.AddModelError(String.Empty, "Никнейм занят");
                return View("SignUp");
            }

            if (existingUserByEmail == null)
            {
                var newUser = new User
                {
                    FirstName = createdUser.FirstName,
                    LastName = createdUser.LastName,
                    UserName = createdUser.UserName,
                    Email = createdUser.Email,
                    Phone = createdUser.Phone,
                    City = createdUser.City,
                    Gender = createdUser.Gender,
                    Password = createdUser.NewPassword,
                    Role = "user"
                };
                usersRepository.Add(newUser);

                CookieOptions option = new CookieOptions();
                option.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Append("userGuid", newUser.Id.ToString(), option);
                Response.Cookies.Append("role", newUser.Role, option);

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(String.Empty, "Пользователь с таким логином уже существует");
                return View("SignUp");
            }

        }
    }
}
