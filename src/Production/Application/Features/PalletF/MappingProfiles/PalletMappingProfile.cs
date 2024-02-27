using Application.Features.PalletF.Commands.CreatePallet;
using Application.Features.PalletF.Commands.UpdatePallet;
using Application.Features.PalletF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.PalletF.MappingProfiles
{
    public class PalletMappingProfile : Profile
    {
        public PalletMappingProfile()
        {
            CreateMap<Pallet, PalletDto>().ReverseMap();

            CreateMap<CreatePalletCommand, Pallet>().ReverseMap();

            CreateMap<UpdatePalletCommand, Pallet>().ForAllMembers(opt => opt.Condition((src, dest, value) => value is int ? (int)value != 0 : value != null));
        }
    }
}