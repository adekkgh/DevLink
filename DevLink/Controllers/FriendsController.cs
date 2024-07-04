﻿using DevLink.Db;
using DevLink.Helpers;
using Microsoft.AspNetCore.Mvc;
using System;

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
            usersRepository.AddFriends(sender, curUser);
            return RedirectToAction("Index");
        }
    }
}
