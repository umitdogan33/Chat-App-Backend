using FluentValidation;

namespace Application.Features.Users.Commands.UpdateUserPhotoCommand;

public class UpdateUserPhotoCommandValidator:AbstractValidator<UpdateUserPhotoCommand>
{
    public UpdateUserPhotoCommandValidator()
    {
        RuleFor(p => p.UserId).NotEmpty();
        RuleFor(p => p.file).NotEmpty();
    }
}