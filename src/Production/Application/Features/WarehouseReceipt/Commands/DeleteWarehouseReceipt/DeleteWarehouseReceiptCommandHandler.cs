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

namespace Application.Features.WarehouseReceipt.Commands.DeleteWarehouseReceipt
{
    public class DeleteWarehouseReceiptCommandHandler : IRequestHandler<DeleteWarehouseReceiptCommand, WarehouseReceiptDto>
    {
        private readonly IWarehouseReceiptRepository _receiptRepository;
        private readonly IWarehouseItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public DeleteWarehouseReceiptCommandHandler(IMapper mapper, IWarehouseItemRepository itemRepository, IWarehouseReceiptRepository receiptRepository)
        {
            _mapper = mapper;
            _itemRepository = itemRepository;
            _receiptRepository = receiptRepository;
        }

        public async Task<WarehouseReceiptDto> Handle(DeleteWarehouseReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _receiptRepository.GetAsync(x => x.Id == request.Id) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_RECEIPT_DOESNT_EXIST);

            var receiptItems = await _itemRepository.Query().Where(x => x.WarehouseReceiptId == receipt.Id && x.IsActive).ToListAsync();

            var deletedReceipt = await _receiptRepository.DeleteAsync(receipt);

            receiptItems.ForEach(item => _itemRepository.DeleteAsync(item));

            var dto = _mapper.Map<WarehouseReceiptDto>(receipt);

            return dto;
        }
    }
}
