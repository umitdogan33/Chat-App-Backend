using Application.Features.Users.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Commands.AddFriendCommand
{
    public class AddFriendCommand:IRequest<AddedFriendDto>
    {
        public string SenderUserId { get; set; }
        public string ReceiverUserId { get; set; }
    }
}
