using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Hubs.HubDto
{
    public class SendMessageDto
    {
        public string Message { get; set; }
        public bool IsPhoto { get; set; }
        public string ReceiverUserId { get; set; }
    }
}
