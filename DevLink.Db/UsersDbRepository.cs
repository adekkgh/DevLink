using DevLink.Db.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DevLink.Db
{
    public class UsersDbRepository : IUsersRepository
    {
        private readonly DatabaseContext databaseContext;

        public UsersDbRepository(DatabaseContext databaseContext)
        {
            this.databaseContext = databaseContext;
        }

        public List<User> GetUsers()
        {
            return databaseContext.Users.ToList();
        }

        public void Add(User user)
        {
            databaseContext.Users.Add(user);
            databaseContext.SaveChanges();
        }

        public User FindByEmail(string email)
        {
            return databaseContext.Users.FirstOrDefault(u => u.Email == email);
        }

        public User FindById(Guid id)
        {
            return databaseContext.Users.Include(u => u.IncomingRequests).Include(u => u.OutgoingRequests).FirstOrDefault(u => u.Id == id);
        }

        public User FindByUsername(string username)
        {
            return databaseContext.Users.FirstOrDefault(u => u.UserName == username);
        }

        public bool IsEmailValid(string email)
        {
            var user = databaseContext.Users.FirstOrDefault(u => u.Email == email);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public bool IsPasswordValid(string email, string password)
        {
            var user = databaseContext.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (user != null)
            {
                return true;
            }
            return false;
        }

        public void ChangeEmail(User user, string newEmail)
        {
            databaseContext.Users.FirstOrDefault(u => u.Id == user.Id).Email = newEmail;
            databaseContext.SaveChanges();
        }

        public void ChangePassword(User user, string newPasword)
        {
            databaseContext.Users.FirstOrDefault(u => u.Id == user.Id).Password = newPasword;
            databaseContext.SaveChanges();
        }

        public List<User> GetFriends(Guid id)
        {
            return databaseContext.Friendships.Where(f => f.UserId == id).Select(f => f.Friend).ToList();
        }
        public List<User> GetPossibleFriends(Guid id)
        {
            var friends = databaseContext.Friendships.Where(f => f.UserId == id).Select(f => f.Friend).ToList();
            var possibleFriends = new List<User>();
            foreach(var user in databaseContext.Users)
            {
                if (!friends.Contains(user) && user.Role != "admin" && user.Id != id && user.IncomingRequests.Where(r => r.SenderId == id).Count() == 0)
                {
                    possibleFriends.Add(user);
                }
            }

            return possibleFriends;
        }

        public void SendFriendRequest(User user,User friend, FriendshipRequest request)
        {
			databaseContext.Users.Include(x => x.OutgoingRequests).FirstOrDefault(u => u.Id == user.Id).OutgoingRequests.Add(request); //ну типа у отправляющего в список добавляется айди принмающего
			databaseContext.Users.Include(x => x.IncomingRequests).FirstOrDefault(u => u.Id == friend.Id).IncomingRequests.Add(request); //а у принимающего наоборот. EF сам это делает.

			databaseContext.SaveChanges();
		}

        public bool CheckFriendRequest(User user, User friend,FriendshipRequest request)
        {
            if (databaseContext.Users.Include(x => x.OutgoingRequests).FirstOrDefault(u => u.Id == user.Id).OutgoingRequests.FirstOrDefault(x => x.SenderId == user.Id) != null                     //это типо если такой запрос уже существует,
                && databaseContext.Users.Include(x => x.IncomingRequests).FirstOrDefault(u => u.Id == friend.Id).IncomingRequests.FirstOrDefault(x => x.AcceptorId == friend.Id) != null) return true;  //то того кто его кидает об этом предупредят
			
            return false;
		}

        public void AddFriends(User user1, User user2)
        {
            Friendship friendship1 = new Friendship() { User = user1, Friend = user2};
			Friendship friendship2 = new Friendship() { User = user2, Friend = user1 };
			databaseContext.Users.FirstOrDefault(u => user1.Id == u.Id).Friendships.Add(friendship1);
			databaseContext.Users.FirstOrDefault(u => user2.Id == u.Id).Friendships.Add(friendship2);

			databaseContext.SaveChanges();
        }

        public void DeleteFriend(User user1, User user2)
        {
            var friendship1 = databaseContext.Friendships.FirstOrDefault(f => f.UserId == user1.Id && f.FriendId == user2.Id);
            var friendship2 = databaseContext.Friendships.FirstOrDefault(f => f.UserId == user2.Id && f.FriendId == user1.Id);
            var friendshipRequest1 = databaseContext.FriendshipRequests.FirstOrDefault(r => r.SenderId == user1.Id || r.AcceptorId == user1.Id);
            var friendshipRequest2 = databaseContext.FriendshipRequests.FirstOrDefault(r => r.SenderId == user2.Id || r.AcceptorId == user2.Id);
            databaseContext.Friendships.Remove(friendship1);
            databaseContext.Friendships.Remove(friendship2);
            databaseContext.FriendshipRequests.Remove(friendshipRequest1);
            databaseContext.FriendshipRequests.Remove(friendshipRequest2);

            databaseContext.SaveChanges();
        }
	}

    public interface IUsersRepository
    {
        public List<User> GetUsers();
        public void Add(User user);
        public User FindByEmail(string email);
        public User FindById(Guid id);
        public User FindByUsername(string username);
        public bool IsEmailValid(string email);
        public bool IsPasswordValid(string email, string password);
        public void ChangeEmail(User user, string newEmail);
        public void ChangePassword(User user, string newPasword);
        public List<User> GetFriends(Guid id);
        public List<User> GetPossibleFriends(Guid id);
        public void SendFriendRequest(User user, User friend, FriendshipRequest request);
        public bool CheckFriendRequest(User user, User friend, FriendshipRequest request);
        public void AddFriends(User user1, User user2);
        public void DeleteFriend(User user1, User user2);
    }
}
