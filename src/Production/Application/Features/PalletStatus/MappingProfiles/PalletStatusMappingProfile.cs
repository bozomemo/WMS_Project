using Application.Features.PalletStatus.Commands.CreatePalletStatus;
using Application.Features.PalletStatus.Commands.UpdatePalletStatus;
using Application.Features.PalletStatus.Dtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletStatus.MappingProfiles
{
    public class PalletStatusMappingProfile : Profile
    {
        public PalletStatusMappingProfile()
        {
            CreateMap<Domain.Entities.PalletStatus, PalletStatusDto>().ReverseMap();

            CreateMap<CreatePalletStatusCommand, Domain.Entities.PalletStatus>().ReverseMap();

            CreateMap<UpdatePalletStatusCommand, Domain.Entities.PalletStatus>().ForAllMembers(opt => opt.Condition((src,dest,value) => value is not null));
        }
    }
}
