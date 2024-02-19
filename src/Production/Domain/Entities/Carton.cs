using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    [Index(nameof(UniqueIdentifier), IsUnique = true)]
    public class Carton : Entity
    {
        public string? Description { get; set; }

        // Can be barcode or some other identifier.
        public string? UniqueIdentifier { get; set; }

        public string? LotNumber { get; set; }

        public int Quantity { get; set; }

        public DateTime ExpirationDate { get; set; }

        public int PalletId { get; set; }
        public virtual Pallet Pallet { get; set; }
    }
}