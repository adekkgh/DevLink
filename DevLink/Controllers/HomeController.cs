using DevLink.Db;
using DevLink.Helpers;
using DevLink.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace DevLink.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IUsersRepository _usersRepository;

        public HomeController(ILogger<HomeController> logger, IUsersRepository usersRepository)
        {
            _logger = logger;
            _usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["userGuid"] == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }

            var georLox = _usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"])).OutgoingRequests;                  // крч я не знаю на кой черт это нужно, но без этого условие в представлении не хочет отрабатывать
            
            var users = Mapping.ToUsersViewModel(_usersRepository.GetPossibleFriends(Guid.Parse(Request.Cookies["userGuid"])));
            return View(users);
        }

        public IActionResult Privacy()
        {
            if (Request.Cookies["userGuid"] == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
