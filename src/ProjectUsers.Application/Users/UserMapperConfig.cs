using AutoMapper;
using ProjectUsers.Application.Users.Commands.Response;
using ProjectUsers.Domain.Entities;

namespace ProjectUsers.Application.Users;

public class UserMapperConfig : Profile
{
    public UserMapperConfig()
    {
        CreateMap<ListUserResponse, User>().ReverseMap();
    }
}
