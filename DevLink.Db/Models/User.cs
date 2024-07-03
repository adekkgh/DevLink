using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db.Models
{
    public class User
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
        public ICollection<Friendship> Friendships { get; set; }
    }
}
