using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.CartonF.Dtos
{
    public class CartonDto
    {
        public int Id { get; set; }
        public string? Description { get; set; }

        // Can be barcode or some other identifier.
        public string? UniqueIdentifier { get; set; }

        public string? LotNumber { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PalletId { get; set; }
    }
}
