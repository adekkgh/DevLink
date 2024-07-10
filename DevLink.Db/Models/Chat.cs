using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db.Models
{
    public class Chat
    {
        public Guid Id { get; set; }
        public bool IsGroupChat{ get; set; }
        public List<User> Users { get; set; }
        public List<Message> Messages { get; set; }

        public Chat()
        {
            Users = new List<User>();
            Messages = new List<Message>();
        }
    }
}
