using Application.Common.Hubs;
using Application.Features.Auth.Dtos;
using Application.Features.Auth.Models;
using Application.Repositories.EntityFramework;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Users.Queries.GetAllByOnline;

public class GetAllUserByOnlineQueryHandler : IRequestHandler<GetAllUserByOnlineQuery, IList<UserListByOnline>>
{
    public List<User> Users { get; set; }
    private IMapper _mapper;
    private IUserRepository _userRepository;

    public GetAllUserByOnlineQueryHandler(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        Users = new();
    }

    public async Task<IList<UserListByOnline>> Handle(GetAllUserByOnlineQuery request, CancellationToken cancellationToken)
    {
        var rowData = ConnectedUser.ClientsData.FindAll(p => p.Status == true).ToList();
        foreach (var item in rowData)
        {
            var data = await _userRepository.GetAsync(p => p.Id == item.UserId);
            Users.Add(data);
        }

        var mappedData = _mapper.Map<List<UserListByOnline>>(Users);
        return mappedData;
    }
}
