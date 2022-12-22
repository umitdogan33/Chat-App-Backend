using Application.Common.Utilities;
using Application.Features.Auth.Dtos;
using Application.Repositories.EntityFramework;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Auth.Commands.UpdateUser;

public class UpdateUserCommandHandler:IRequestHandler<UpdateUserCommand,UpdatedUserDto>
{
    private IUserRepository _userRepository;
    private IMapper _mapper;

    public UpdateUserCommandHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<UpdatedUserDto> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        HashingHelper.CreatePasswordHash(request.Password,out byte[] passwordHash,out byte[] passwordSalt);
        var updateData = await _userRepository.GetAsync(p=>p.Id == request.UserId);
        updateData.Email = request.Email;
        updateData.Username = request.Username;
        updateData.FirstName = request.FirstName;
        updateData.LastName = request.LastName;
        updateData.PasswordHash = passwordHash;
        updateData.PasswordSalt = passwordSalt;

        await _userRepository.UpdateAsync(updateData);
        return new UpdatedUserDto() {Success = true};
    }
}