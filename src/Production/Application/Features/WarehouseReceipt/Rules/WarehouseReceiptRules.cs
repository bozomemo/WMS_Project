using Application.Services.Repositories;
using Core.CrossCuttingConcerns.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Rules
{
    public class WarehouseReceiptRules
    {
        readonly IWarehouseReceiptRepository _receiptRepository;

        public WarehouseReceiptRules(IWarehouseReceiptRepository receiptRepository)
        {
            _receiptRepository = receiptRepository;
        }

        public async Task EnsureWarehouseReceiptDoesntExist(Domain.Entities.WarehouseReceipt receipt)
        {
            var tempReceipt = await _receiptRepository.GetAsync(x => x.IsActive && x.OrderNo == receipt.OrderNo && x.DeliveryNoteNo == receipt.DeliveryNoteNo);
            if (tempReceipt is not null) throw new BusinessException("A record already exists with this order number and delivery note number! Please check the information!");
        }
    }
}
