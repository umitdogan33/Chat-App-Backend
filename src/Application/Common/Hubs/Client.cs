using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Hubs
{
    public class Client
    {
        public string UserId { get; set; }
        public string ConnectionId { get; set; }

        public bool Status { get; set; }

    }
}
