using Application.Features.WarehouseReceipt.Dtos;
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

namespace Application.Features.WarehouseReceipt.Commands.UpdateWarehouseReceipt
{
    public class UpdateWarehouseReceiptCommandHandler : IRequestHandler<UpdateWarehouseReceiptCommand, WarehouseReceiptDto>
    {
        private readonly IWarehouseReceiptRepository _warehouseReceiptRepository;
        private readonly IWarehouseItemRepository _warehouseReceiptItemRepository;
        private readonly IMapper _mapper;

        public UpdateWarehouseReceiptCommandHandler(IMapper mapper, IWarehouseItemRepository warehouseReceiptItemRepository, IWarehouseReceiptRepository warehouseReceiptRepository)
        {
            _mapper = mapper;
            _warehouseReceiptItemRepository = warehouseReceiptItemRepository;
            _warehouseReceiptRepository = warehouseReceiptRepository;
        }

        public async Task<WarehouseReceiptDto> Handle(UpdateWarehouseReceiptCommand request, CancellationToken cancellationToken)
        {
            var itemDtos = new List<WarehouseItemDto>();

            var warehouseReceipt = await _warehouseReceiptRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_RECEIPT_DOESNT_EXIST);

            if(warehouseReceipt.WarehouseReceiptItems is not null && warehouseReceipt.WarehouseReceiptItems.Count != 0)
            {
                foreach (var item in warehouseReceipt.WarehouseReceiptItems)
                {
                    var warehouseReceiptItem = await _warehouseReceiptItemRepository.GetAsync(x => x.Id == item.WarehouseReceiptId) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_ITEM_DOESNT_EXIST);

                    var deletedReceiptItem = await _warehouseReceiptItemRepository.DeleteAsync(warehouseReceiptItem);

                    itemDtos.Add(_mapper.Map<WarehouseItemDto>(deletedReceiptItem));
                }
            }

            _mapper.Map(request, warehouseReceipt);

            var updatedReceipt = await _warehouseReceiptRepository.UpdateAsync(warehouseReceipt);

            var dto = _mapper.Map<WarehouseReceiptDto>(updatedReceipt);

            return dto;
            
        }
    }
}
