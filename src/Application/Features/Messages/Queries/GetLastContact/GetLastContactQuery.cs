using Application.Features.Messages.Dtos;
using Domain.Entities;
using Domain.Entities.Common;
using MediatR;

namespace Application.Features.Messages.Queries.GetLastContact;

public class GetLastContactQuery:IRequest<List<LastContactsUser>>
{
    public string UserId { get; set; }
}