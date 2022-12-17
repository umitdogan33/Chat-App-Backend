using Application.Features.Messages.Dtos;
using Application.Repositories.EntityFramework;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Queries.GetAllMessageByUserId;

public class GetAllMessageByUserIdQueryHandler:IRequestHandler<GetAllMessageByUserIdQuery,IList<MessageEntity>>
{
    private readonly IMessageRepository _messageRepository;

    public GetAllMessageByUserIdQueryHandler(IMessageRepository messageRepository)
    {
        _messageRepository = messageRepository;
    }

    public async Task<IList<MessageEntity>> Handle(GetAllMessageByUserIdQuery request, CancellationToken cancellationToken)
    {
        var data = await _messageRepository.GetAllAsync(p=>(p.ReceverId == request.UserId && p.SenderId == request.UserId2) || (p.ReceverId == request.UserId2 && p.SenderId == request.UserId));
        data = data.OrderBy(x=>x.CreateDate).ToList();
        return data;
    }
}