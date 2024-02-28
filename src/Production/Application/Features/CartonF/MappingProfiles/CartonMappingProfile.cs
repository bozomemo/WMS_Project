using Application.Features.CartonF.Commands.CreateCarton;
using Application.Features.CartonF.Commands.UpdateCarton;
using Application.Features.CartonF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.MappingProfiles
{
    public class CartonMappingProfile : Profile
    {
        public CartonMappingProfile()
        {
            CreateMap<Carton, CartonDto>().ReverseMap();

            CreateMap<CreateCartonCommand, Carton>().ReverseMap();

            CreateMap<UpdateCartonCommand, Carton>().ForAllMembers(opt => opt.Condition((src,dest,value) => value is int ? (int)value != 0 : value is not null));
        }
    }
}
