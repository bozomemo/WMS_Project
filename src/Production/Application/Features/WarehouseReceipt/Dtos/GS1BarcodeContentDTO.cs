using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.WarehouseReceipt.Dtos
{
    public class GS1BarcodeContentDTO
    {
        public string? ContentGTIN {  get; set; }

        public string? BestBefore { get; set; }

        public string? LotNumber { get; set; }

        public int? Quantity { get; set; }

        public string? InternalContent { get; set; }
    }
}
