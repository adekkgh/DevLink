﻿using DevLink.Db.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
            return databaseContext.Users.FirstOrDefault(u => u.Id == id);
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
                if (!friends.Contains(user) && user.Role != "admin")
                {
                    possibleFriends.Add(user);
                }
            }

            return possibleFriends;
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

    }
}
