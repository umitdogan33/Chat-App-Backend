using Application.Features.Auth.Dtos;
using Application.Features.Users.Dtos;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace Application.Features.Users.Commands.UpdateUserPhotoCommand;

public class UpdateUserPhotoCommand:IRequest<UpdatedUserPhotoDto>
{
    public string UserId { get; set; }
    public IFormFile file { get; set; }
}