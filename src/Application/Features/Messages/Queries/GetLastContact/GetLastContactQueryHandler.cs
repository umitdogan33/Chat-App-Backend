using Application.Features.Messages.Dtos;
using Domain.Entities;
using Application.Repositories.EntityFramework;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Common;
using MediatR;

namespace Application.Features.Messages.Queries.GetLastContact;

public class GetLastContactQueryHandler:IRequestHandler<GetLastContactQuery,List<LastContactsUser>>
{
    private readonly IMapper _mapper;
    private readonly IMessageRepository _messageRepository;

    public GetLastContactQueryHandler(IMapper mapper, IMessageRepository messageRepository)
    {
        _mapper = mapper;
        _messageRepository = messageRepository;
    }

    public async Task<List<LastContactsUser>> Handle(GetLastContactQuery request, CancellationToken cancellationToken)
    {
        var data =await _messageRepository.GetLastContact(request.UserId);
        return data;
    }
}