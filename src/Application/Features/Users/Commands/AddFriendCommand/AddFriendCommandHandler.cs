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

namespace Application.Features.Users.Commands.AddFriendCommand
{
    public class AddFriendCommandHandler : IRequestHandler<AddFriendCommand, AddedFriendDto>
    {
        private readonly IFriendRequestRepository _repository;
        private readonly IMapper _mapper;

        public AddFriendCommandHandler(IFriendRequestRepository repository, IMapper mapper)
        {
            _repository=repository;
            _mapper=mapper;
        }

        public async Task<AddedFriendDto> Handle(AddFriendCommand request, CancellationToken cancellationToken)
        {
           await _repository.AddAsync(new Friend(Guid.NewGuid().ToString(),request.SenderUserId,request.ReceiverUserId,false));
            return new AddedFriendDto() {Success=true };
        }
    }
}
