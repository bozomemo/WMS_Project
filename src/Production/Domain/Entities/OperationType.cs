using Core.Persistence.Repositories;

namespace Domain.Entities
{
    public class OperationType : Entity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int WarehouseId { get; set; }
        public virtual Warehouse Warehouse { get; set; }
    }
}