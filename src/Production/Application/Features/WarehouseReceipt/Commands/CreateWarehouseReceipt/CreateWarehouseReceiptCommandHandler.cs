using Application.Features.WarehouseReceipt.Dtos;
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
        private readonly IMapper _mapper;

        public CreateWarehouseReceiptCommandHandler(IMapper mapper, IWarehouseItemRepository itemRepository, IWarehouseReceiptRepository receiptRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _receiptRepository = receiptRepository;
        }

        public async Task<WarehouseReceiptDto> Handle(CreateWarehouseReceiptCommand request, CancellationToken cancellationToken)
        {
            var warehouseReceiptItems = _mapper.Map<List<WarehouseItem>>(request.WarehouseReceiptItems);

            var warehouseReceipt = _mapper.Map<Domain.Entities.WarehouseReceipt>(request);

            var addedWarehouseReceipt = await _receiptRepository.AddAsync(warehouseReceipt);

            var receiptDto = _mapper.Map<WarehouseReceiptDto>(addedWarehouseReceipt);

            receiptDto.WarehouseReceiptItems = [];

            warehouseReceiptItems.ForEach(async item => 
            {
                var addedItem = await _itemRepository.AddAsync(item);

                var addedDto = _mapper.Map<WarehouseItemDto>(addedItem);

                receiptDto.WarehouseReceiptItems.Add(addedDto);
            });

            return receiptDto;
        }
    }
}
