using Application.Features.Users.Dtos;
using MediatR;

namespace Application.Features.Users.Commands.ChangeUsername;
public class ChangeFeelTextCommand:IRequest<ChangeFeelTextDto>
{
    public string UserId { get; set; }
    public string FeelText { get; set; }
}