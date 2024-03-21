using Application.Features.Shipment.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Shipment.Commands.DeleteShipment
{
    public class DeleteShipmentCommandHandler : IRequestHandler<DeleteShipmentCommand, ShipmentDto>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IMapper _mapper;

        public DeleteShipmentCommandHandler(IMapper mapper, IShipmentRepository shipmentRepository)
        {
            _mapper = mapper;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ShipmentDto> Handle(DeleteShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.SHIPMENT_DOESNT_EXIST);

            var deletedShipment = await _shipmentRepository.DeleteAsync(shipment);

            var dto = _mapper.Map<ShipmentDto>(deletedShipment);

            return dto;
        }
    }
}
