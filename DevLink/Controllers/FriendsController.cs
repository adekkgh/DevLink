using DevLink.Db;
using DevLink.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Reflection;

namespace DevLink.Controllers
{
    public class FriendsController : Controller
    {
        private readonly IUsersRepository usersRepository;

        public FriendsController(IUsersRepository usersRepository)
        {
            this.usersRepository = usersRepository;
        }

        public IActionResult Index()
        {
            if (Request.Cookies["userGuid"] == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }

            var friends = usersRepository.GetFriends(Guid.Parse(Request.Cookies["userGuid"]));     //берет список друзей для пользователя, которого берет из кук
            var friendsView = Mapping.ToUsersViewModel(friends);

            return View(friendsView);
        }
        public IActionResult AddFriend(Guid id)
        {
			if (Request.Cookies["userGuid"] == null)
			{
				return RedirectToAction("LogIn", "Auth");
			}

			var sender = usersRepository.FindById(id);
            var curUser = usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"]));

			sender.OutgoingRequests.FirstOrDefault(r => r.SenderId == sender.Id).IsAccept = true;
			curUser.IncomingRequests.FirstOrDefault(r => r.AcceptorId == curUser.Id).IsAccept = true;

			usersRepository.AddFriends(sender, curUser);

			return RedirectToAction("Index");
        }

        public IActionResult DeleteFriend(Guid friendId)
        {
            if (Request.Cookies["userGuid"] == null)
            {
                return RedirectToAction("LogIn", "Auth");
            }

            var user1 = usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"]));
            var user2 = usersRepository.FindById(friendId);

            usersRepository.DeleteFriend(user1, user2);

            return RedirectToAction("Index");
        }
    }
}
