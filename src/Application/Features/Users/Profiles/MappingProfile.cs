using Application.Features.Users.Dtos;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Users.Profiles;

public class MappingProfile:Profile
{
    public MappingProfile()
    {
        CreateMap<GetUserByIdDto,User>().ReverseMap();
    }
}