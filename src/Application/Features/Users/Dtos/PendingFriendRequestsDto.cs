using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Dtos
{
    public class PendingFriendRequestsDto
    {
        public IList<User> FromOtherUser { get; set; }
        public IList<User> FromMe { get; set; }
    }
}
