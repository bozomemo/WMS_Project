using Application.Features.WarehouseF.Commands.CreateWarehouse;
using Application.Features.WarehouseReceipt.Commands.ApproveWarehouseReceipt;
using Application.Features.WarehouseReceipt.Commands.CreateWarehouseReceipt;
using Application.Features.WarehouseReceipt.Commands.UpdateWarehouseReceipt;
using Application.Features.WarehouseReceipt.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.MappingProfiles
{
    public class WarehouseReceiptMappingProfile : Profile
    {
        public WarehouseReceiptMappingProfile()
        {
            CreateMap<Domain.Entities.WarehouseReceipt, WarehouseReceiptDto>().ReverseMap();

            CreateMap<WarehouseItem, WarehouseItemDto>().ReverseMap();

            CreateMap<ApproveReceiptItem, WarehouseItem>().ReverseMap();

            CreateMap<CreateWarehouseReceiptCommand, Domain.Entities.WarehouseReceipt>().ReverseMap();

            CreateMap<UpdateWarehouseReceiptCommand, Domain.Entities.WarehouseReceipt>().ForAllMembers(opt => opt.Condition((src, dest, value) => value is int ? (int)value != 0 : value is not null));
        }
    }
}
