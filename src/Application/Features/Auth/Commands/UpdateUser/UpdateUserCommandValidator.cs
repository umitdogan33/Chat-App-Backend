using FluentValidation;

namespace Application.Features.Auth.Commands.UpdateUser;

public class UpdateUserCommandValidator:AbstractValidator<UpdateUserCommand>
{
    public UpdateUserCommandValidator()
    {
        RuleFor(p => p.Email).NotEmpty().NotNull();
        RuleFor(p => p.Password).NotEmpty().NotNull();
        RuleFor(p => p.Username).NotEmpty().NotNull();
        RuleFor(p => p.FirstName).NotEmpty().NotNull();
        RuleFor(p => p.LastName).NotEmpty().NotNull();
        RuleFor(p => p.UserId).NotEmpty().NotNull();
    }
}