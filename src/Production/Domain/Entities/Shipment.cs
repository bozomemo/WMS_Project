using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Shipment : Entity
    {
        public required string OrderNo { get; set; }
        /// <summary>
        /// İrsaliye numarası
        /// </summary>
        public required string DeliveryNoteNo { get; set; }

        public bool Approved { get; set; }

        public bool HasIrregularProducts { get; set; }

        public int? ApprovedByUserId { get; set; }

        public int CreatedByUserId { get; set; }

        public virtual ICollection<WarehouseItem> ShipmentItems { get; set; }

    }
}
