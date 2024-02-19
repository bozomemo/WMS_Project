using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class Zone : Entity
    {
        public string ZoneCode { get; set; }

        public string? Description { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }

        public bool IsBin { get; set; }
    }
}