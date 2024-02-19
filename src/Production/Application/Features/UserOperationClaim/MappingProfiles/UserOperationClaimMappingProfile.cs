using Application.Features.UserOperationClaim.Commands.UpdateUserOperationClaim;
using Application.Features.UserOperationClaim.Dtos;
using AutoMapper;
using Domain.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.UserOperationClaim.MappingProfiles
{
    public class UserOperationClaimMappingProfile : Profile
    {
        public UserOperationClaimMappingProfile()
        {
            CreateMap<Core.Security.Entities.UserOperationClaim, UserOperationClaimDto>()
                .ForMember(x => x.UserId, opt => opt.MapFrom(x => x.User.Id))
                .ForMember(x => x.Username, opt => opt.MapFrom(x => x.User.Username))
                .ForMember(x => x.UserEmail, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.OperationClaimId, opt => opt.MapFrom(x => x.OperationClaim.Id))
                .ForMember(x => x.OperationClaimName, opt => opt.MapFrom(x => x.OperationClaim.Name)).ReverseMap();

            CreateMap<Core.Security.Entities.UserOperationClaim, EntityIdDto>().ReverseMap();

            CreateMap<UpdateUserOperationClaimCommand, Core.Security.Entities.UserOperationClaim>().ForMember(x => x.Id, opt => opt.Ignore()).ReverseMap();
        }
    }
}
