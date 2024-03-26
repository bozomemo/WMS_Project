using Application.Features.WarehouseReceipt.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Commands.ApproveWarehouseReceipt
{
    public class ApproveWarehouseReceiptCommand : IRequest<WarehouseReceiptApproveDto>
    {
        public int WarehouseReceiptId { get; set; }

        public ApproveReceiptItem[]? ApproveReceiptItems { get; set; }

        public bool CloseReceipt { get; set; }
    }

    public record ApproveReceiptItem(int Id, int Quantity, int OkQuantity, int IrregularQuantity, string ReceiptItemNote, string? Title, string? Description, string? Barcode, string? ItemNo);
}
