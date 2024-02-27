using Application.Features.WarehouseF.Commands.CreateWarehouse;
using Application.Features.WarehouseF.Commands.UpdateWarehouse;
using Application.Features.WarehouseF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseF.MappingProfiles
{
    public class WarehouseMappingProfile : Profile
    {
        public WarehouseMappingProfile()
        {
            CreateMap<CreateWarehouseCommand, Warehouse>().ReverseMap();

            CreateMap<UpdateWarehouseCommand, Warehouse>().ForMember(x => x.Id, opt => opt.Ignore()).ForAllMembers(options => options.Condition((src, dest, value) => value != null));

            CreateMap<WarehouseDto, Warehouse>().ReverseMap();
        }
    }
}
