using Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Friend:Entity
    {
        public Friend(string id,string senderUserId, string receiverUserId, bool accept):base(id)
        {
            SenderUserId=senderUserId;
            ReceiverUserId=receiverUserId;
            Accept=accept;
        }

        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
        public bool Accept { get; set; }
    }
}
