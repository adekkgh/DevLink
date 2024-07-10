using System;
using System.Collections.Generic;
using System.Text;

namespace DevLink.Db.Models
{
    public class Message
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public DateTime SendedAt { get; set; }
        public User Sender { get; set; }
    }
}
