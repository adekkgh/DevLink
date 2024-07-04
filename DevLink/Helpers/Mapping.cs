using DevLink.Db.Models;
using DevLink.Models;
using DevLink.Views.Shared.Components.User;
using System.Collections.Generic;

namespace DevLink.Helpers
{
	public static class Mapping
	{
		public static List<UserViewModel> ToUsersViewModel(List<User> users)
		{
			var usersView = new List<UserViewModel>();
			foreach (var user in users)
			{
				usersView.Add(new UserViewModel
				{
					Id = user.Id,
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email,
					City = user.City,
					Gender = user.Gender,
					Password = user.Password,
					Phone = user.Phone,
					Role = user.Role,
					UserName = user.UserName,
					IncomingRequests = ToFriendshipRequestsViewModel(user.IncomingRequests),
					OutgoingRequests = ToFriendshipRequestsViewModel(user.OutgoingRequests)
				});
			}
			return usersView;
		}

		public static UserViewModel ToUserViewModel(User user)
		{
			return new UserViewModel
			{
				Id = user.Id,
				FirstName = user.FirstName,
				LastName = user.LastName,
				Email = user.Email,
				City = user.City,
				Gender = user.Gender,
				Password = user.Password,
				Phone = user.Phone,
				Role = user.Role,
				UserName = user.UserName,
				IncomingRequests = ToFriendshipRequestsViewModel(user.IncomingRequests),
				OutgoingRequests = ToFriendshipRequestsViewModel(user.OutgoingRequests)
			};
		}
		public static List<FriendshipRequestViewModel> ToFriendshipRequestsViewModel(List<FriendshipRequest> friendshipRequest)
		{
			var res = new List<FriendshipRequestViewModel>();
			foreach(var item in friendshipRequest)
			{
				res.Add(ToFriendshipRequestsViewModel(item));
			}
			return res;
		}

		public static FriendshipRequestViewModel ToFriendshipRequestsViewModel(FriendshipRequest friendshipRequest)
		{
			return new FriendshipRequestViewModel
			{
				Id = friendshipRequest.Id,
				SenderId = friendshipRequest.SenderId,
				AcceptorId = friendshipRequest.AcceptorId,
				IsAccept = friendshipRequest.IsAccept
			};
		}
	}
}
