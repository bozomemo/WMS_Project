using Application.Features.Shipment.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.Queries.GetShipmentById
{
    public class GetShipmentByIdQueryHandler : IRequestHandler<GetShipmentByIdQuery, ShipmentDto>
    {
        private readonly IShipmentRepository _repository;
        private readonly IMapper _mapper;

        public GetShipmentByIdQueryHandler(IMapper mapper, IShipmentRepository repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ShipmentDto> Handle(GetShipmentByIdQuery request, CancellationToken cancellationToken)
        {
            var shipment = await _repository.Query().Include(x => x.ShipmentItems).Where(x => x.Id == request.Id).FirstOrDefaultAsync() ?? throw new BusinessException(BusinessExceptionConstants.SHIPMENT_DOESNT_EXIST);
            
            var dto = _mapper.Map<ShipmentDto>(shipment);

            return dto;
        }
    }
}
