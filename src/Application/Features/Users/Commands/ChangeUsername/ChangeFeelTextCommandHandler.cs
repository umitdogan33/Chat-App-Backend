using Application.Features.Users.Dtos;
using Application.Repositories.EntityFramework;
using MediatR;

namespace Application.Features.Users.Commands.ChangeUsername;
public class ChangeFeelTextCommandHandler : IRequestHandler<ChangeFeelTextCommand, ChangeFeelTextDto>
{
    private IUserRepository _userRepository;

    public ChangeFeelTextCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<ChangeFeelTextDto> Handle(ChangeFeelTextCommand request, CancellationToken cancellationToken)
    {
       var user = await _userRepository.GetAsync(p=>p.Id == request.UserId);
       user.FeelText = request.FeelText;
       await _userRepository.UpdateAsync(user);
       return new ChangeFeelTextDto(){Success = true};
    }
}