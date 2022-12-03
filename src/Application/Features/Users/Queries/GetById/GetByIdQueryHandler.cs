using Application.Features.Users.Dtos;
using Application.Repositories.EntityFramework;
using AutoMapper;
using MediatR;

namespace Application.Features.Users.Queries.GetById;

public class GetByIdQueryHandler:IRequestHandler<GetUserByIdQuery,GetUserByIdDto>
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;

    public GetByIdQueryHandler(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<GetUserByIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var fetchedData = await _userRepository.GetAsync(p=>p.Id == request.UserId);
        return _mapper.Map<GetUserByIdDto>(fetchedData);
    }
}