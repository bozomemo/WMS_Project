using Application.Features.OperationClaim.Commands.UpdateOperationClaim;
using Application.Features.OperationClaim.Dtos;
using Application.Features.OperationClaimFeature.Commands.CreateOperationClaim;
using Application.Features.OperationClaimFeature.Dtos;
using AutoMapper;
using Core.Security.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationClaim.MappingProfiles
{
    public class OperationClaimProfile : Profile
    {
        public OperationClaimProfile()
        {
            CreateMap<Core.Security.Entities.OperationClaim, OperationClaimDto>().ReverseMap();

            CreateMap<Core.Security.Entities.OperationClaim, UpdateOperationClaimCommand>().ReverseMap();

            CreateMap<Core.Security.Entities.OperationClaim, CreateOperationClaimCommand>().ReverseMap();

            CreateMap<Core.Security.Entities.OperationClaim, OperationClaimWithIdDto>().ReverseMap();
        }
    }
}
