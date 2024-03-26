using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class ProductPool : Entity
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public required string Barcode { get; set; }

        public int? SupplierId { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
