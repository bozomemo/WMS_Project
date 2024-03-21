using Application.Features.PalletTypeF.Commands.CreatePalletType;
using Application.Features.PalletTypeF.Commands.UpdatePalletType;
using Application.Features.PalletTypeF.Dtos;
using Application.Features.Shipment.Commands.CreateShipment;
using Application.Features.Shipment.Commands.UpdateShipment;
using Application.Features.Shipment.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.MappingProfiles
{
    public class ShipmentMappingProfile : Profile
    {
        public ShipmentMappingProfile()
        {
            CreateMap<Domain.Entities.Shipment, ShipmentDto>().ReverseMap();

            CreateMap<CreateShipmentCommand, Domain.Entities.Shipment>().ReverseMap();

            CreateMap<UpdateShipmentCommand, Domain.Entities.Shipment>().ForAllMembers(options => options.Condition((src, dest, value) => value is not null));
        }
    }
}
