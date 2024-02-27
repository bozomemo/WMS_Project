using Application.Features.SupplierF.Commands.CreateSupplier;
using Application.Features.SupplierF.Commands.UpdateSupplier;
using Application.Features.SupplierF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.SupplierF.MappingProfiles
{
    public class SupplierMappingProfile : Profile
    {
        public SupplierMappingProfile()
        {
            CreateMap<Supplier, SupplierDto>().ReverseMap();

            CreateMap<CreateSupplierCommand, Supplier>();

            CreateMap<UpdateSupplierCommand, Supplier>().ForAllMembers(opt => opt.Condition((src, dest, value) => value is not null));
        }
    }
}
