using Application.Features.Users.Commands.CreateUserCommand;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Auth.MappingProfiles
{
    public class AuthMappingProfiles : Profile
    {
        public AuthMappingProfiles()
        {
            CreateMap<CreateUserCommand, User>().ReverseMap();
        }
    }
}