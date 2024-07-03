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
					FirstName = user.FirstName,
					LastName = user.LastName,
					Email = user.Email,
					City = user.City,
					Gender = user.Gender,
					Password = user.Password,
					Phone = user.Phone,
					Role = user.Role,
					UserName = user.UserName,
					Id = user.Id
				});
			}
			return usersView;
		}
	}
}
