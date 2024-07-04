using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db.Models
{
	public class FriendshipRequest
	{
		public Guid Id { get; set; }
		public Guid SenderId { get; set; }		//тут гвиды, тк на юзеров почему-то EF жалуется, хотя так было бы удобнее
		public Guid AcceptorId { get; set; }
		public bool IsAccept { get; set; } = false;
	}
}
