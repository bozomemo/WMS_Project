using Application.Features.Zone.Commands.CreateZone;
using Application.Features.Zone.Commands.UpdateZone;
using Application.Features.Zone.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Zone.MappingProfiles
{
    public class ZoneMappingProfile : Profile
    {
        public ZoneMappingProfile()
        {
            CreateMap<Domain.Entities.Zone, ZoneDto>().ReverseMap();

            CreateMap<CreateZoneCommand, Domain.Entities.Zone>().ReverseMap();

            CreateMap<UpdateZoneCommand, Domain.Entities.Zone>().ForAllMembers(opt => opt.Condition((src,dst,value) => value is int val ? val != 0 : value is not null));
        }
    }
}
