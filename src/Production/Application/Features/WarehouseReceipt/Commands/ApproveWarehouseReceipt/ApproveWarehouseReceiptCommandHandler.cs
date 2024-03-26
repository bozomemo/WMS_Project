using Application.Features.WarehouseReceipt.Dtos;
using Application.Services.Repositories;
using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using Domain.Constants;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Commands.ApproveWarehouseReceipt
{
    public class ApproveWarehouseReceiptCommandHandler : IRequestHandler<ApproveWarehouseReceiptCommand, WarehouseReceiptApproveDto>
    {
        private readonly IWarehouseReceiptRepository _warehouseReceiptRepository;
        private readonly IWarehouseItemRepository _itemRepository;

        public ApproveWarehouseReceiptCommandHandler(IWarehouseItemRepository itemRepository, IWarehouseReceiptRepository warehouseReceiptRepository)
        {
            _itemRepository = itemRepository;
            _warehouseReceiptRepository = warehouseReceiptRepository;
        }

        public async Task<WarehouseReceiptApproveDto> Handle(ApproveWarehouseReceiptCommand request, CancellationToken cancellationToken)
        {
            var receipt = await _warehouseReceiptRepository.GetAsync(x => x.Id == request.WarehouseReceiptId) ?? throw new BusinessException(BusinessExceptionConstants.WAREHOUSE_RECEIPT_DOESNT_EXIST);

            if (request?.ApproveReceiptItems is not null)
            {
                foreach (var receiptItem in request.ApproveReceiptItems)
                {
                    var item = await _itemRepository.GetAsync(x => x.Id == receiptItem.Id);
                    var irregular = receiptItem.IrregularQuantity > 0;

                    if (item is not null)
                    {
                        if (irregular)
                        {
                            item.CountedQuantity = receiptItem.IrregularQuantity;
                            item.IsIrregular = true;
                            item.ReceiptItemNote = receiptItem.ReceiptItemNote;
                        }
                        else
                        {
                            item.CountedQuantity = receiptItem.OkQuantity;
                            item.ReceiptItemNote = receiptItem.ReceiptItemNote;
                        }
                        await _itemRepository.UpdateAsync(item);
                    }
                    else if (irregular)
                    {
                        WarehouseItem newItem = new WarehouseItem
                        {
                            IsIrregular = true,
                            ItemNo = receiptItem.ItemNo ?? "",
                            Title = receiptItem.Title ?? "",
                            Barcode = receiptItem.Barcode,
                            CountedQuantity = receiptItem.IrregularQuantity,
                            Description = receiptItem.Description,
                            Quantity = receiptItem.Quantity,
                            ReceiptItemNote = receiptItem.ReceiptItemNote,
                            WarehouseReceiptId = receipt.Id
                        };

                        await _itemRepository.AddAsync(newItem);
                    }


                }
            }

            throw new NotImplementedException();
        }
    }
}