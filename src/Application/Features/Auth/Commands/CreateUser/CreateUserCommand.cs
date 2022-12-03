using Application.Features.Auth.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Auth.Commands.CreateUserCommand;

public class CreateUserCommand : IRequest<CreatedUserDto>
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public IFormFile photo { get; set; }
    public string Password { get; set; }
}
