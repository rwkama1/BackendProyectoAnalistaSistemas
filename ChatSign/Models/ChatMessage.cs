using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatSign.Models
{
    public class ChatMessage

    {
        public string user { get; set; }
        public string message { get; set; }
        public string room { get; set; }

        public ChatMessage(string user, string message, string room)
        {
            this.user = user;
            this.message = message;
            this.room = room;
        }

        public ChatMessage()
        {
        }
    }
}
