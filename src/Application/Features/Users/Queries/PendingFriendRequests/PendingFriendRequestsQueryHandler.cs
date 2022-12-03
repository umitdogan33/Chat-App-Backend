using Application.Features.Users.Dtos;
using Application.Repositories.EntityFramework;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Users.Queries.PendingFriendRequests
{
    public class PendingFriendRequestsQueryHandler : IRequestHandler<PendingFriendRequestsQuery, PendingFriendRequestsDto>
    {
        public List<User> FromOtherUsers { get; set; }
        public List<User> FromMe { get; set; }
        private IFriendRequestRepository _friendRequestRepository;
        private IUserRepository _userRepository;
        private IMapper _mapper;

        public PendingFriendRequestsQueryHandler(IFriendRequestRepository friendRequestRepository, IUserRepository userRepository, IMapper mapper)
        {
            FromOtherUsers = new List<User>();
            FromMe = new List<User>();
            _friendRequestRepository=friendRequestRepository;
            _userRepository=userRepository;
            _mapper=mapper;
        }

        public async Task<PendingFriendRequestsDto> Handle(PendingFriendRequestsQuery request, CancellationToken cancellationToken)
        {
            var data = await _friendRequestRepository.GetAllAsync(p=>p.ReceiverUserId == request.UserId);
            var senderUser = await _friendRequestRepository.GetAllAsync(p=>p.SenderUserId == request.UserId);
            foreach (var item in data)
            {
                FromOtherUsers.Add(await _userRepository.GetAsync(p=>p.Id == item.Id));
            }

            foreach (var item in senderUser)
            {
                FromMe.Add(await _userRepository.GetAsync(p => p.Id == item.Id));
            }
            return new PendingFriendRequestsDto {
            FromMe = FromMe,
            FromOtherUser = FromOtherUsers
            };

        }
    }
}
