using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Dtos
{
    public class WarehouseReceiptDto
    {
        public int Id { get; set; }
        public string? OrderNo { get; set; }

        /// <summary>
        /// İrsaliye numarası
        /// </summary>
        public string? DeliveryNoteNo { get; set; }

        public bool? Approved { get; set; }

        public bool? HasIrregularProducts { get; set; }

        public int? ApprovedByUserId { get; set; }

        public int? CreatedByUserId { get; set; }

        public HashSet<WarehouseReceiptItemDto>? WarehouseReceiptItems { get; set; }
    }
}