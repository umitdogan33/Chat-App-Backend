using Application.Features.Users.Dtos;
using Domain.Entities;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetUserByIdQuery:IRequest<GetUserByIdDto>
{
    public string UserId { get; set; }
}