using Application.Features.PalletTypeF.Commands.CreatePalletType;
using Application.Features.PalletTypeF.Commands.UpdatePalletType;
using Application.Features.PalletTypeF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletTypeF.MappingProfiles
{
    public class PalletTypeMappingProfile : Profile
    {
        public PalletTypeMappingProfile()
        {
            CreateMap<PalletType, PalletTypeDto>().ReverseMap();

            CreateMap<CreatePalletTypeCommand, PalletType>().ReverseMap();

            CreateMap<UpdatePalletTypeCommand, PalletType>().ForAllMembers(options => options.Condition((src,dest,value) => value is not null));
        }
    }
}
