using Application.Features.OperationTypeF.Commands.CreateOperationType;
using Application.Features.OperationTypeF.Commands.UpdateOperationType;
using Application.Features.OperationTypeF.Dtos;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OperationTypeF.MappingProfiles
{
    public class OperationTypeMapping : Profile
    {
        public OperationTypeMapping()
        {
            CreateMap<OperationType, OperationTypeDto>().ReverseMap();

            CreateMap<CreateOperationTypeCommand, OperationType>().ReverseMap();

            CreateMap<UpdateOperationTypeCommand, OperationType>().ForMember(x => x.Id, opt => opt.Ignore()).ForAllMembers(options => options.Condition((src, dest, value) => value != null));
        }
    }
}
