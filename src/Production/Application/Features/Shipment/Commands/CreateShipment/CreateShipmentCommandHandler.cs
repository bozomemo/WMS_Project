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

namespace Application.Features.Shipment.Commands.CreateShipment
{
    public class CreateShipmentCommandHandler : IRequestHandler<CreateShipmentCommand, ShipmentDto>
    {
        private readonly IShipmentRepository _repository;
        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IMapper _mapper;

        public CreateShipmentCommandHandler(IMapper mapper, IWarehouseItemRepository warehouseItemRepository, IShipmentRepository repository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
            _repository = repository;
        }

        public async Task<ShipmentDto> Handle(CreateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = _mapper.Map<Domain.Entities.Shipment>(request) ?? throw new BusinessException(BusinessExceptionConstants.SHIPMENT_MAPPING_NOT_SUCCESSFULL);

            shipment?.ShipmentItems.ToList().ForEach(async shipmentItem => await _warehouseItemRepository.AddAsync(shipmentItem));

            var addedShipment = await _repository.AddAsync(shipment!);

            var dto = _mapper.Map<ShipmentDto>(addedShipment);

            return dto;
        }
    }
}
