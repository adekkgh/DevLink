using DevLink.Db.Models;
using System;

namespace DevLink.Models
{
	public class FriendshipRequestViewModel
	{
		public Guid Id { get; set; }
		public Guid SenderId { get; set; }
		public Guid AcceptorId { get; set; }
		public bool IsAccept { get; set; } = false;
	}
}
