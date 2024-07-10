using Microsoft.AspNetCore.Mvc;

namespace DevLink.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DirectMessage()
        {
            return View();
        }

        public IActionResult GroupChat()
        {
            return View();
        }
    }
}
