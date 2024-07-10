using DevLink.Db;
using DevLink.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace DevLink.Controllers
{
    public class AdminController : Controller
    {
        private readonly IUsersRepository usersRepository;
        public AdminController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }
        public IActionResult Users()
        {
            var users = usersRepository.GetUsers();
            return View(Mapping.ToUsersViewModel(users));
        }
    }
}
