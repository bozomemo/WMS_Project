using Application.Features.WarehouseReceipt.Dtos;
using Application.Features.WarehouseReceipt.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Commands.CreateWarehouseReceipt
{
    public class CreateWarehouseReceiptCommandHandler : IRequestHandler<CreateWarehouseReceiptCommand, WarehouseReceiptDto>
    {
        private readonly IWarehouseReceiptRepository _receiptRepository;
        private readonly IWarehouseItemRepository _itemRepository;
        private readonly WarehouseReceiptRules _warehouseReceiptRules;
        private readonly IMapper _mapper;

        public CreateWarehouseReceiptCommandHandler(IMapper mapper, IWarehouseItemRepository itemRepository, IWarehouseReceiptRepository receiptRepository, WarehouseReceiptRules warehouseReceiptRules)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _receiptRepository = receiptRepository;
            _warehouseReceiptRules = warehouseReceiptRules;
        }

        public async Task<WarehouseReceiptDto> Handle(CreateWarehouseReceiptCommand request, CancellationToken cancellationToken)
        {
            var warehouseReceiptItems = _mapper.Map<List<WarehouseItem>>(request.WarehouseReceiptItems);

            var warehouseReceipt = _mapper.Map<Domain.Entities.WarehouseReceipt>(request);

            await _warehouseReceiptRules.EnsureWarehouseReceiptDoesntExist(warehouseReceipt);

            var addedWarehouseReceipt = await _receiptRepository.AddAsync(warehouseReceipt);

            var receiptDto = _mapper.Map<WarehouseReceiptDto>(addedWarehouseReceipt);

            receiptDto.WarehouseReceiptItems = [];

            foreach (var item in warehouseReceiptItems)
            {
                item.WarehouseReceiptId = warehouseReceipt.Id;

                var addedItem = await _itemRepository.AddAsync(item);

                var addedDto = _mapper.Map<WarehouseItemDto>(addedItem);

                receiptDto.WarehouseReceiptItems.Add(addedDto);
            }

            return receiptDto;
        }
    }
}
