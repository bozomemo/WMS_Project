using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    [Index(nameof(Barcode),nameof(ItemNo))]
    public class WarehouseItem : Entity
    {
        public required string Title { get; set; }

        public string? Description { get; set; }

        public required string ItemNo { get; set; }

        public string? Barcode { get; set; }

        public int Quantity { get; set; }

        public int TotalExpectedQuantity { get; set; }

        public int CountedQuantity { get; set; }

        public bool IsIrregular { get; set; }


        public int? WarehouseReceiptId { get; set; }
        public virtual WarehouseReceipt? WarehouseReceipt { get; set; }

        public int? ShipmentId { get; set; }
        public virtual Shipment? Shipment { get; set; }
    }
}
