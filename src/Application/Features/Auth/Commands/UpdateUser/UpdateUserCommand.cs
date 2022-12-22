using Application.Features.Auth.Dtos;
using MediatR;

namespace Application.Features.Auth.Commands.UpdateUser;

public class UpdateUserCommand:IRequest<UpdatedUserDto>
{
    public string UserId { get; set; }
    public string Username { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
}