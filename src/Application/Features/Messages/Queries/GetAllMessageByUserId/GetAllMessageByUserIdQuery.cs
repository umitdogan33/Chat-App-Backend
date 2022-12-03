using Application.Features.Messages.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Features.Messages.Queries.GetAllMessageByUserId;

public class GetAllMessageByUserIdQuery:IRequest<IList<MessageEntity>>
{
    public string UserId { get; set; }
    public string UserId2 { get; set; }
}