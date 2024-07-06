using DevLink.Db;
using DevLink.Db.Models;
using DevLink.Helpers;
using DevLink.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace DevLink.Controllers
{
	public class FriendshipRequestController : Controller
	{
		private readonly IUsersRepository usersRepository;
		private readonly IFriendshipRequests friendshipRequestsRepository;

		public FriendshipRequestController(IUsersRepository usersRepository, IFriendshipRequests friendshipRequests)
		{
			this.usersRepository = usersRepository;
			friendshipRequestsRepository = friendshipRequests;
		}

		public IActionResult Add(Guid id)
		{
			if (Request.Cookies["userGuid"] == null)
			{
				return RedirectToAction("LogIn", "Auth");
			}
			
			var sender = usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"]));
			var acceptor = usersRepository.FindById(id);
			var request = new FriendshipRequest()
			{
				//Id = Guid.NewGuid(),
				SenderId = sender.Id,
				AcceptorId = acceptor.Id
			};

			if (usersRepository.CheckFriendRequest(sender, acceptor,request))
			{
				return RedirectToAction("Warning");
			}

			usersRepository.SendFriendRequest(sender, acceptor, request);
			return RedirectToAction("Sent");
		}

		public IActionResult Sent()
		{
			if(Request.Cookies["userGuid"] == null)
			{
				return RedirectToAction("LogIn", "Auth");
			}

			var requests = usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"])).OutgoingRequests;
			var res = new List<UserViewModel>();

			foreach (var request in requests)
			{
				if(!request.IsAccept)
				{
					var user = usersRepository.FindById(request.AcceptorId); //тут сохраняем список принимающих, т.е. тех кому мы кинули
					res.Add(Mapping.ToUserViewModel(user));
				}
			}

			return View(res);
		}
		public IActionResult Incoming()
		{
			if (Request.Cookies["userGuid"] == null)
			{
				return RedirectToAction("LogIn", "Auth");
			}

			var requests = usersRepository.FindById(Guid.Parse(Request.Cookies["userGuid"])).IncomingRequests;
			var res = new List<UserViewModel>();

			foreach (var request in requests)
			{
				if(!request.IsAccept)
				{
					var user = usersRepository.FindById(request.SenderId);  //а тут список отправителей, т.е. тех кто кинул нам
					res.Add(Mapping.ToUserViewModel(user));
				}
			}

			return View(res);
		}

		public IActionResult Warning()
		{
			return View();
		}
	}
}
