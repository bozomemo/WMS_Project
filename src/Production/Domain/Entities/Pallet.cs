using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Pallet : Entity
    {
        public string Barcode { get; set; }

        public string? Description { get; set; }

        public int SupplierId { get; set; }
        public virtual Supplier Supplier { get; set; }

        public virtual List<Carton> Cartons { get; set; }

        public int ZoneId { get; set; }
        public virtual Zone Zone { get; set; }

        public int StatusId { get; set; }
        public virtual PalletStatus Status { get; set; }

        public int PalletTypeId { get; set; }
        public virtual PalletType PalletType { get; set; }
    }
}