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

namespace Application.Features.Shipment.Commands.UpdateShipment
{
    public class UpdateShipmentCommandHandler : IRequestHandler<UpdateShipmentCommand, ShipmentDto>
    {
        private readonly IShipmentRepository _shipmentRepository;
        private readonly IWarehouseItemRepository _warehouseItemRepository;
        private readonly IMapper _mapper;

        public UpdateShipmentCommandHandler(IMapper mapper, IWarehouseItemRepository warehouseItemRepository, IShipmentRepository shipmentRepository)
        {
            _mapper = mapper;
            _warehouseItemRepository = warehouseItemRepository;
            _shipmentRepository = shipmentRepository;
        }

        public async Task<ShipmentDto> Handle(UpdateShipmentCommand request, CancellationToken cancellationToken)
        {
            var shipment = await _shipmentRepository.Query().Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken: cancellationToken) ?? throw new BusinessException(BusinessExceptionConstants.SHIPMENT_DOESNT_EXIST);

            request.ShipmentItems?.ToList()?.ForEach(async shipmentItem => 
            {
                var warehouseItem = await _warehouseItemRepository.GetAsync(x => x.Id == shipmentItem.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_ITEM_DOESNT_EXIST);

                _mapper.Map(warehouseItem, shipmentItem);

                var updatedShipmentItem = await _warehouseItemRepository.UpdateAsync(warehouseItem);
            });

            _mapper.Map(request, shipment);

            var updatedShipment = await _shipmentRepository.UpdateAsync(shipment);

            var dto = _mapper.Map<ShipmentDto>(updatedShipment);

            return dto;
        }
    }
}
