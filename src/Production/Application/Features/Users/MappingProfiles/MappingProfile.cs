using Application.Features.Users.Commands.UpdateUserCommand;
using AutoMapper;
using Core.Security.Entities;

namespace Application.Features.Users.MappingProfiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<User, Dtos.UserDto>().ForAllMembers(options =>
            {
                options.Condition((src, dest, value) => value != null);
            });

            CreateMap<UpdateUserCommand, User>().ForMember(x => x.Id, options => options.Ignore())
                .ForAllMembers(options => options.Condition((src, dest, value) => value != null));
        }
    }
}