using DevLink.Db;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Drawing;
using System.Linq;

namespace DevLink.Views.Shared.Components.FriendshipRequest
{
    public class FriendshipRequestViewComponent : ViewComponent
    {
        private readonly IUsersRepository usersRepository;
        private readonly IHttpContextAccessor httpContextAccessor;

        public FriendshipRequestViewComponent(IHttpContextAccessor httpContextAccessor, IUsersRepository usersRepository)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.usersRepository = usersRepository;
        }

        public IViewComponentResult Invoke()
        {
            var id = httpContextAccessor.HttpContext.Request.Cookies["userGuid"];
            if (id == null)
            {
                return View("FriendshipRequest", "unauthorized");
            }

            var user = usersRepository.FindById(Guid.Parse(id));
            if(user.IncomingRequests.Where(r => !r.IsAccept).ToList().Count > 0)
            {
                return View("FriendshipRequest", user.IncomingRequests.Where(r => !r.IsAccept).ToList().Count.ToString());
            }

            return View("FriendshipRequest", "");
        }
    }
}
