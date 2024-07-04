using DevLink.Db.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db
{
	public class FriendshipRequestsDbRepository : IFriendshipRequests
	{
		private readonly DatabaseContext databaseContext;
		private readonly IUsersRepository usersRepository;

		public FriendshipRequestsDbRepository(DatabaseContext databaseContext, IUsersRepository usersRepository)
		{
			this.databaseContext = databaseContext;
			this.usersRepository = usersRepository;
		}

		public void AddRequest(User sender, User acceptor)
		{
			databaseContext.FriendshipRequests.Add(new FriendshipRequest()
			{
				//Sender = sender,
				//Acceptor = sender,
				IsAccept = true			//пока пусть при отправлении заявки она автоматически принимается. КОСТЫЛЬ
			});
			databaseContext.SaveChanges();
		}

		
	}

	public interface IFriendshipRequests
	{
		public void AddRequest(User sender, User acceptor);
	}
}
