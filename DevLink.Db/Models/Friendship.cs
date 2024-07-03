using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db.Models
{
    public class Friendship
    {
        public Guid UserId { get; set; }
        public User User { get; set; }

        public Guid FriendId { get; set; }
        public User Friend { get; set; }
    }
}
