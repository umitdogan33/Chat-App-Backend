using Application.Common.Utilities;
using Application.Features.Users.Dtos;
using Application.Repositories.EntityFramework;
using MediatR;

namespace Application.Features.Users.Commands.UpdateUserPhotoCommand;

public class UpdateUserPhotoCommandHandler:IRequestHandler<UpdateUserPhotoCommand,UpdatedUserPhotoDto>
{
    private IUserRepository _userRepository;

    public UpdateUserPhotoCommandHandler(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UpdatedUserPhotoDto> Handle(UpdateUserPhotoCommand request, CancellationToken cancellationToken)
    {
        var url = FileUploadHelper.Upload(request.file);
        var user = await _userRepository.GetAsync(p=>p.Id == request.UserId);
        user.PhotoUrl = url;
        await _userRepository.UpdateAsync(user);
        return new UpdatedUserPhotoDto() {PhotoUrl = url};
    }
}