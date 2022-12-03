using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class MessageEntity:Entity
    {
        public MessageEntity()
        {
        }

        public MessageEntity(string senderId, string receverId, string message)
        {
            SenderId=senderId;
            ReceverId=receverId;
            Message=message;
        }

        public string SenderId { get; set; }
        public string ReceverId { get; set; }
        public string Message { get; set; }
    }
}
