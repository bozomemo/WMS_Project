using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Dtos
{
    public class WarehouseItemDto
    {
        public int Id {  get; set; }
        public string? Title { get; set; }

        public string? Description { get; set; }

        public string? ItemNo { get; set; }

        public string? Barcode { get; set; }

        public int Quantity { get; set; }

        public int TotalExpectedQuantity { get; set; }

        public int CountedQuantity { get; set; }

        public bool? IsIrregular { get; set; }
    }
}
